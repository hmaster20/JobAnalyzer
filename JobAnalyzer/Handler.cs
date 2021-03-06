﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace JobAnalyzer
{
    class Handler
    {
        VacancyCollection _VacancySearchCollection { get; set; }

        public Handler()
        {
            _VacancySearchCollection = new VacancyCollection();
        }

        //https://msdn.microsoft.com/ru-ru/library/456dfw4f(v=vs.110).aspx
        //https://krasnodar.hh.ru/search/vacancy
        /*
         *?text=C%23                    //Ключевые слова
         * &search_field=name           //Искать только = в названии вакансии
         * &search_field=description    //Искать только = в описании вакансии
         * &specialization=1            //Профессиональная область = Информационные технологии, интернет, телеком
         * &area=1                      //Регион = Москва
         * &area=2                      //Регион = Санкт-Петербург
         * &area=53                     //Регион = Краснодар
         * &area=1001                   //Регион = Другие страны
         * &salary=                     //Уровень заработной платы
         * &currency_code=RUR           //Тип валюты
         * &only_with_salary=true       //Скрыть вакансии без указания зарплаты
         * &experience=doesNotMatter    //Требуемый опыт работы
         * &order_by=relevance          //Сортировать = По соответствию
         * &search_period=              //Выводить = За месяц
         * &search_period=1             //Выводить = За сутки
         * &items_on_page=20            //Показывать на странице = 20 вакансий
         * &no_magic=true     
         */

        public List<Class.Item> FindAllVacancies(string query)
        {
            //string URL = "https://api.hh.ru/vacancies" + query + "&search_field=name";
            string URL = "https://api.hh.ru/vacancies" + query;

            List<Class.Item> ListItems = new List<Class.Item>();
            Class.RootObject VacRObj = new Class.RootObject();

            int page_num = 0;
            string source = GetSource(URL);
            if (!string.IsNullOrWhiteSpace(source))
            {

                try
                {
                    VacRObj = JsonConvert.DeserializeObject<Class.RootObject>(source);

                    Debug.WriteLine(VacRObj.found);
                    Debug.WriteLine(VacRObj.pages);
                    Debug.WriteLine(VacRObj.per_page);

                    ListItems.AddRange(VacRObj.items);

                    if (VacRObj.pages > 0)
                    {
                        while (page_num < VacRObj.pages)
                        {
                            page_num++;
                            source = GetSource(URL + "&page=" + page_num);
                            VacRObj = JsonConvert.DeserializeObject<Class.RootObject>(source);
                            ListItems.AddRange(VacRObj.items);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return ListItems;
        }

        public Class.Vacancy.RootObject GetVacContent(string url)
        {
            string source = GetSource(url);

            Class.Vacancy.RootObject VacContent = new Class.Vacancy.RootObject();
            if (!string.IsNullOrWhiteSpace(source))
            {
                VacContent = JsonConvert.DeserializeObject<Class.Vacancy.RootObject>(source);
            }
            return VacContent;
        }

        public List<Area> GetCountry()
        {
            string source = GetSource("https://api.hh.ru/areas/countries");

            List<Area> ar = new List<Area>();
            List<Area> CollectVac = JsonConvert.DeserializeObject<List<Area>>(source);
            foreach (var item in CollectVac)
            {
                ar.Add(item);
            }
            return ar;
        }

        public Vacancy GetVacancy(string vac)
        {
            if (vac.Length > 0)
            {
                string source = GetSource("https://api.hh.ru/vacancies/" + vac);

                Vacancy translation = new Vacancy();
                if (!string.IsNullOrWhiteSpace(source))
                {
                    translation = JsonConvert.DeserializeObject<Vacancy>(source);
                }

                return translation;
            }
            else
                return null;
        }

        public Grafik GetGrafik()
        {
            string source = GetSource("https://api.hh.ru/dictionaries");

            Grafik CollectVac = new Grafik();
            if (!string.IsNullOrWhiteSpace(source))
            {
                CollectVac = JsonConvert.DeserializeObject<Grafik>(source);
            }
            return CollectVac;
        }

        public Areas GetRegions(string coderRegion)
        {
            string source = GetSource("https://api.hh.ru/areas/" + coderRegion);

            Areas CollectVac = new Areas();
            if (!string.IsNullOrWhiteSpace(source))
            {
                CollectVac = JsonConvert.DeserializeObject<Areas>(source);
            }
            return CollectVac;
        }

        public List<Specs> GetSpecs()
        {
            string source = GetSource("https://api.hh.ru/specializations");

            List<Specs> CollectSpecs = new List<Specs>();
            if (!string.IsNullOrWhiteSpace(source))
            {
                CollectSpecs = JsonConvert.DeserializeObject<List<Specs>>(source);
            }
            return CollectSpecs;
        }

        public string GetSource(string url)
        {
            string line = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    line = stream.ReadLine();
                }
            }
            catch (WebException exc)
            {
                //GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            //catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return line;
        }

        private static void GetErrorDesciption(WebException exc)
        {
            using (StreamReader stream = new StreamReader(exc.Response.GetResponseStream()))
            {
                string line;
                if ((line = stream.ReadLine()) != null)
                {
                    Err translation = JsonConvert.DeserializeObject<Err>(line);
                }
            }
        }
    }
}
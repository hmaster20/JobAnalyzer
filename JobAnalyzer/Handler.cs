using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace JobAnalyzer
{
    class Handler
    {
        VacancyCollection _VacancySearchCollection { get; set; }

        public Handler()
        {
            _VacancySearchCollection = new VacancyCollection();
        }

        public object FindAllVacancies(string query)
        {
            //https://krasnodar.hh.ru/search/vacancy
            /*
             *?text=C%23                    //Ключевые слова
             * &search_field=name           //Искать только = в названии вакансии
             * &search_field=description    //Искать только = в описании вакансии
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

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/vacancies" + query + "&search_field=name");
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        Search CollectVac = JsonConvert.DeserializeObject<Search>(line);

                        foreach (var item in CollectVac.items)
                        {
                            _VacancySearchCollection.Add(item);
                        }
                        _VacancySearchCollection.Save();
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return "";
        }


        public string GetVacancy(string vac)
        {
            if (vac.Length > 0)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create("https://api.hh.ru/vacancies/" + vac);
                request.Method = "GET";
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.UserAgent = "JobAnalyzer - .NET Framework Client";

                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        string line;
                        if ((line = stream.ReadLine()) != null)
                        {
                            Vacancy translation = JsonConvert.DeserializeObject<Vacancy>(line);
                        }
                    }
                }
                catch (WebException exc)
                {
                    GetErrorDesciption(exc);
                    MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
                }
                catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
                catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
                catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
                catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
                catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
                catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

                return vac;
            }
            else
                return "";
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




        public Grafik GetGrafik()
        {
            Grafik CollectVac = new Grafik();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/dictionaries");
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

            //Encoding.Convert(Encoding.Unicode, Encoding.UTF8,)
            //s = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(s));
            //Где s – это нужная строка.
            //Вместо Unicode можно также выбирать: ASCII, UTF32, UTF7, UTF8 и Default.

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        CollectVac = JsonConvert.DeserializeObject<Grafik>(line);
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return CollectVac;
        }



        public List<Area> GetCountry()
        {
            List<Area> ar = new List<Area>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/areas/countries");
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        List<Area> CollectVac = JsonConvert.DeserializeObject<List<Area>>(line);

                        foreach (var item in CollectVac)
                        {
                            ar.Add(item);
                        }
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return ar;
        }



        public Areas GetRegions(string coderRegion)
        {
            Areas CollectVac = new Areas();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/areas/" + coderRegion);
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        CollectVac = JsonConvert.DeserializeObject<Areas>(line);
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return CollectVac;
        }
    }
}


//https://msdn.microsoft.com/ru-ru/library/456dfw4f(v=vs.110).aspx


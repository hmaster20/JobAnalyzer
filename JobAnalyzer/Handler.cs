using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
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

        public string FindVacancy(string key)
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

            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("https://api.hh.ru/vacancies"
                + "?text=" + key
                + "&area=" + 53
                 + "&search_period=" + 1
                 + "&search_field=name");

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

                        // parsing
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

                            // parsing
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
    }
}

//https://msdn.microsoft.com/ru-ru/library/456dfw4f(v=vs.110).aspx


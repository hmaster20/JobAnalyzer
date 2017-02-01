using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace JobAnalyzer
{
    class Handler
    {
        public string FindVacancy(string word)
        {  



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


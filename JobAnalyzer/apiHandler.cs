using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JobAnalyzer
{
    class apiHandler
    {
        public string FindVacancy(string word)
        {
            return "";
        }

        public string GetVacancy(string vac)
        {
            vac = "19490253";

            if (vac.Length > 0)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/vacancies/" + "vac");
                request.Method = "GET";
                request.Accept = "application/json";
                request.UserAgent = ".NET Framework Test Client";

                try
                {
                    //,"address\":{\"building\":\"46бк1\",\"city\":\"Москва\",\"description\":null,\"metro\":{\"line_name\":\"Таганско-Краснопресненская\",\"station_id\":\"7.139\",\"line_id\":\"7\",\"lat\":55.709211,\"station_name\":\"Текстильщики\",\"lng\":37.732117},\"metro_stations\":[{\"line_name\":\"Таганско-Краснопресненская\",\"station_id\":\"7.139\",\"line_id\":\"7\",\"lat\":55.709211,\"station_name\":\"Текстильщики\",\"lng\":37.732117}],"raw\":null,\"street\":\"Волгоградский проспект\",\"lat\":55.70461,\"lng\":37.726385},\

                    //,\"employer\":{\"logo_urls\":{\"90\":\"https://hhcdn.ru/employer-logo/1430073.jpeg\",\"original\":\"https://hhcdn.ru/employer-logo-original/246850.jpg\",\"240\":\"https://hhcdn.ru/employer-logo/1430074.jpeg\"},                    
                    //"vacancies_url\":\"https://api.hh.ru/vacancies?employer_id=1733392\",\"name\":\"АВАРТ СИСТЕМС\",\"url\":\"https://api.hh.ru/employers/1733392\",\"alternate_url\":\"https://hh.ru/employer/1733392\",\"id\":\"1733392\",\"trusted\":true},

                    //\"response_letter_required\":false,\"apply_alternate_url\":\"https://hh.ru/applicant/vacancy_response?vacancyId=19490253\",
                    //\"quick_responses_allowed\":true,\"negotiations_url\":null,\"department\":null,\"branded_description\":null,\"hidden\":false,\
                    //"type\":{\"id\":\"open\",\"name\":\"Открытая\"},
                    //\"specializations\":[{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.221\",\"name\":\"Программирование, Разработка\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.272\",\"name\":\"Системная интеграция\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.161\",\"name\":\"Мультимедиа\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.82\",\"name\":\"Инженер\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.420\",\"name\":\"Администратор баз данных\"},{\"profarea_id\":\"25\",\"profarea_name\":\"Инсталляция и сервис\",\"id\":\"25.386\",\"name\":\"Инсталляция и настройка оборудования\"}]}"


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
                catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
                return vac;
            }
            else
                return "";
        }
    }

    class Vacancy
    {
        public string description { get; set; }

        public string name { get; set; }

        public int id { get; set; }
        public bool archived { get; set; }

        public string alternate_url { get; set; }

        public bool allow_messages { get; set; }

        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }

        public string city { get; set; }
        public Dictionary<string, string> department { get; set; }
        public Dictionary<string, string> salary { get; set; }

        public Dictionary<string, string> schedule { get; set; } // Занятость
        public Dictionary<string, string> employment { get; set; } // Занятость

        public Dictionary<string, string> experience { get; set; } // опыт в годах

        public Dictionary<string, string> area { get; set; } // здесь есть город

        public Dictionary<string, string> type { get; set; } // можно проверить открытость вакансии 
    }
}

//https://msdn.microsoft.com/ru-ru/library/456dfw4f(v=vs.110).aspx


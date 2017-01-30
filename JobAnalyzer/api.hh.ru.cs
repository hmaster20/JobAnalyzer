using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JobAnalyzer
{
    class hh_vacancies
    {
        public string FindVacancy(string word)
        {
            return "";
        }

        public string GetVacancy(string vac)
        {
            if (vac.Length > 0)
            {
                //WebRequest request = WebRequest.Create("https://api.hh.ru/vacancies/"
                //    + "8252535");
                //+ "&lang=" + lang);
              

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/vacancies/19490253");

                request.Method = "GET";
                request.Accept = "application/json";
                request.UserAgent = ".NET Framework Test Client";

                try
                {
                    //"{\"alternate_url\":\"https://hh.ru/vacancy/19490253\",\"code\":null,\"premium\":true,\"description\":\"<p><strong>О компании:</strong></p> <ul> <li><strong>АВАРТ СИСТЕМС </strong><strong>- компания, реализующая интегрированные комплексные проекты в области информационно-коммуникационных технологий</strong></li> <li><strong>Специализация </strong>- интегрированные комплексные решения в области аудиовизуальных технологий</li> <li><strong>Состав решений – </strong>системы отображения, системы видеокоммутации, системы аудиокоммутации, индивидуальные рабочие места, интерактивные средства работы с информацией, конференц-системы, системы озвучивания, системы записи, системы мониторинга, системы управления и пр.</li> <li><strong>Разработка и внедрение собственных аппаратно-программных комплексов для АВ-индустрии</strong></li> </ul> <p> </p> <p>В связи с расширением штата Аварт Системс приглашает на работу Инженера-программиста в отдел разработки.</p> <p> </p> <p><strong>Обязанности</strong><strong>:</strong></p> <ul> <li>Разработка собственных продуктов для АВ-индустрии (графические видеопроцессоры, системы управления, СПО визуализации и другие продукты)</li> <li>Участие во внедрении разработанных продуктов в проекты</li> <li>Оформление технической документации</li> </ul> <p> </p> <p><strong>Требования:</strong></p> <ul> <li>Профессиональный уровень кандидата: Middle-Senior или Senior. Знание: C#,WPF,Mono,C++, Qt, Python, PostgreSQL, HTTP, REST, Visual Studio 2015, Git, Linux</li> <li>Высшее техническое образование</li> <li>Отличные знания C#,C++, опыт разработки от года</li> <li>Опыт разработки под Linux (Ubuntu)</li> <li>Знания стандартных алгоритмов</li> <li>Хорошее знание Python, SQL</li> <li>Понимание принципов работы клиент-серверной архитектуры, работы web приложений, сайтов, REST API</li> <li>Опыт работы с Git</li> <li>Знание английского языка на уровне чтения технической документации</li> <li>Работоспособность</li> <li>Стрессоустойчивость</li> <li>Стремление к профессиональному совершенству</li> </ul> <p><strong>Дополнительно:</strong></p> <ul> <li>Хорошие знания библиотек STL, Qt, boost</li> <li>Знание дополнительных языков программирования</li> <li>Навыки системного администрирования Linux/Ubuntu</li> </ul> <p> </p> <p><strong>Условия:</strong></p> <ul> <li>Заработная плата по результатам собеседования</li> <li>Оформление по ТК РФ</li> <li>График работы: 10.00 – 19.00, Офис - 10 мин. пешком от ст.м.Текстильщики</li> <li>Профильное обучение в РФ и за рубежом</li> </ul>\",\"schedule\":{\"id\":\"fullDay\",\"name\":\"Полный день\"},\"suitable_resumes_url\":null,\"site\":{\"id\":\"hh\",\"name\":\"hh.ru\"},\"billing_type\":{\"id\":\"premium\",\"name\":\"Премиум\"},\"published_at\":\"2017-01-24T15:05:12+0300\",\"test\":null,\"accept_handicapped\":false,\"experience\":{\"id\":\"between3And6\",\"name\":\"От 3 до 6 лет\"},\"address\":{\"building\":\"46бк1\",\"city\":\"Москва\",\"description\":null,\"metro\":{\"line_name\":\"Таганско-Краснопресненская\",\"station_id\":\"7.139\",\"line_id\":\"7\",\"lat\":55.709211,\"station_name\":\"Текстильщики\",\"lng\":37.732117},\"metro_stations\":[{\"line_name\":\"Таганско-Краснопресненская\",\"station_id\":\"7.139\",\"line_id\":\"7\",\"lat\":55.709211,\"station_name\":\"Текстильщики\",\"lng\":37.732117}],\"raw\":null,\"street\":\"Волгоградский проспект\",\"lat\":55.70461,\"lng\":37.726385},\"key_skills\":[],\"allow_messages\":true,\"employment\":{\"id\":\"full\",\"name\":\"Полная занятость\"},\"id\":\"19490253\",\"response_url\":null,\"salary\":null,\"archived\":false,\"name\":\"Инженер-программист\",\"contacts\":null,\"created_at\":\"2017-01-24T15:05:12+0300\",\"area\":{\"url\":\"https://api.hh.ru/areas/1\",\"id\":\"1\",\"name\":\"Москва\"},\"relations\":[],\"employer\":{\"logo_urls\":{\"90\":\"https://hhcdn.ru/employer-logo/1430073.jpeg\",\"original\":\"https://hhcdn.ru/employer-logo-original/246850.jpg\",\"240\":\"https://hhcdn.ru/employer-logo/1430074.jpeg\"},\"vacancies_url\":\"https://api.hh.ru/vacancies?employer_id=1733392\",\"name\":\"АВАРТ СИСТЕМС\",\"url\":\"https://api.hh.ru/employers/1733392\",\"alternate_url\":\"https://hh.ru/employer/1733392\",\"id\":\"1733392\",\"trusted\":true},\"response_letter_required\":false,\"apply_alternate_url\":\"https://hh.ru/applicant/vacancy_response?vacancyId=19490253\",\"quick_responses_allowed\":true,\"negotiations_url\":null,\"department\":null,\"branded_description\":null,\"hidden\":false,\"type\":{\"id\":\"open\",\"name\":\"Открытая\"},\"specializations\":[{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.221\",\"name\":\"Программирование, Разработка\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.272\",\"name\":\"Системная интеграция\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.161\",\"name\":\"Мультимедиа\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.82\",\"name\":\"Инженер\"},{\"profarea_id\":\"1\",\"profarea_name\":\"Информационные технологии, интернет, телеком\",\"id\":\"1.420\",\"name\":\"Администратор баз данных\"},{\"profarea_id\":\"25\",\"profarea_name\":\"Инсталляция и сервис\",\"id\":\"25.386\",\"name\":\"Инсталляция и настройка оборудования\"}]}"

                    // WebResponse response = request.GetResponse();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        string line;
                        if ((line = stream.ReadLine()) != null)
                        {
                            Vacancy translation = JsonConvert.DeserializeObject<Vacancy>(line);


                            //s = "";

                            //foreach (string str in translation.text)
                            //    s += str;
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
        public string city { get; set; }

        public Dictionary<string, string> department { get; set; }

        public Dictionary<string, string> salary { get; set; }

        public string name { get; set; }

    }
}

//https://msdn.microsoft.com/ru-ru/library/456dfw4f(v=vs.110).aspx


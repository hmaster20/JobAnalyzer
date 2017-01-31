using System;
using System.Collections.Generic;

namespace JobAnalyzer
{
    class Vacancy
    {
        public Vacancy()
        {
            employer = new Employer();
            specializations = new Specializations[] { };
            type = new Type();
            salary = new Salary();
            experience = new Experience();
            schedule = new Schedule();
            key_skills = new Key_skills[] { };
        }
        public string description { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public bool archived { get; set; }
        public string alternate_url { get; set; }
        public bool allow_messages { get; set; }
        public bool response_letter_required { get; set; }
        public string apply_alternate_url { get; set; }
        public bool quick_responses_allowed { get; set; }
        public string negotiations_url { get; set; }
        public string branded_description { get; set; }
        public bool hidden { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public string city { get; set; }
        public Dictionary<string, string> department { get; set; }  // подразделение компании
        public Dictionary<string, string> employment { get; set; }  // Занятость
        public Dictionary<string, string> area { get; set; }        // здесь есть город
        public Key_skills[] key_skills { get; set; }
        public Schedule schedule { get; set; }
        public Experience experience { get; set; }
        public Salary salary { get; set; }
        public Employer employer { get; set; }
        public Specializations[] specializations { get; set; }
        public Type type { get; set; }
    }

    /// <summary>
    /// Работодатель
    /// </summary>
    class Employer
    {
        public Dictionary<string, string> logo_urls { get; set; } // original Ссылка на логотип работодателя https://hhcdn.ru/employer-logo-original/246850.jpg\
        public string vacancies_url { get; set; }   // ссылка на вакансии через API вида https://api.hh.ru/vacancies?employer_id=1733392\
        public string name { get; set; }    // Наименование компании работодателя
        public string url { get; set; }     // ссылка на информацию работодателя через API вида https://api.hh.ru/employers/1733392\
        public string alternate_url { get; set; }   // ссылка на информацию работодателя через HH.ru вида https://hh.ru/employer/1733392\
        public string original { get; set; }
        public int id { get; set; }         // Идентификатор компании
        public bool trusted { get; set; }
    }

    /// <summary>
    /// Специализация
    /// </summary>
    class Specializations
    {
        public float id { get; set; }
        public string name { get; set; }        // Название: Программирование, Разработка
        public int profarea_id { get; set; }
        public string profarea_name { get; set; }   // Направление: Информационные технологии, интернет, телеком
    }

    /// <summary>
    /// Зарплата
    /// </summary>
    class Salary
    {
        public string to { get; set; }          // null
        public string from { get; set; }        //2000
        public string currency { get; set; }    // USD
    }

    /// <summary>
    /// Доступность (открытость) вакансии
    /// </summary>
    class Type
    {
        public string id { get; set; }      // open
        public string name { get; set; }    // Открытая
    }

    /// <summary>
    /// Требуемый опыт работы в годах
    /// </summary>
    class Experience
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    /// <summary>
    /// График работы
    /// </summary>
    class Schedule
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    /// <summary>
    /// Ключевые навыки
    /// </summary>
    class Key_skills
    {
        public string name { get; set; }
    }

    class Address
    {
        public Address()
        {
            metro = new Metro();
            metro_stations = new Metro_stations[] { };
        }
        public Metro metro { get; set; }
        public Metro_stations[] metro_stations { get; set; }

        public string building { get; set; }    // 46бк1
        public string city { get; set; }    //Москва
        public string description { get; set; }
        public string street { get; set; }  // Волгоградский проспект
        public float lat { get; set; }      // 55.709211
        public float lng { get; set; }      // 37.732117

        //,"raw\":null,\"       
    }

    class Metro
    {
        public string line_name { get; set; } // Таганско-Краснопресненская
        public float station_id { get; set; } // 7.139
        public int line_id { get; set; }  // 7
        public float lat { get; set; } // 55.709211
        public string station_name { get; set; } // Текстильщики
        public float lng { get; set; } // 37.732117
    }

    class Metro_stations : Metro
    {
        //public string line_name { get; set; } // Таганско-Краснопресненская
        //public float station_id { get; set; } // 7.139
        //public int line_id { get; set; }  // 7
        //public float lat { get; set; } // 55.709211
        //public string station_name { get; set; } // Текстильщики
        //public float lng { get; set; } // 37.732117       
    }


}

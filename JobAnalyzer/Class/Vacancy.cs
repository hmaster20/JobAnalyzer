﻿using System;
using System.Collections.Generic;

namespace JobAnalyzer
{
 
    /// <summary>
    /// Класс вакансий
    /// </summary>
    class Vacancy : VacancyGlobal
    {
        public Vacancy()
        {
            specializations = new Specializations[] { };
            experience = new Experience();
            schedule = new Schedule();
            key_skills = new Key_skills[] { };
            employment = new Employment();
        }
        public string description { get; set; }
        public bool allow_messages { get; set; }
        public bool quick_responses_allowed { get; set; }
        public string negotiations_url { get; set; }
        public string branded_description { get; set; }
        public bool hidden { get; set; }
        public Key_skills[] key_skills { get; set; }
        public Experience experience { get; set; }
        public Schedule schedule { get; set; }
        public Employment employment { get; set; }
        public Specializations[] specializations { get; set; }

        //  public string city { get; set; }
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
    /// Подразделение
    /// </summary>
    class Department
    {
        public string id { get; set; }      // HH-1455-TECH
        public string name { get; set; }    // HeadHunter::Технический департамент
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
        public string from { get; set; }        // 30000
        public string to { get; set; }          // 35000
        public string currency { get; set; }    // RUR или USD
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
        public string id { get; set; }  // between1And3
        public string name { get; set; }    //"От 1 года до 3 лет
    }

    /// <summary>
    /// График работы
    /// </summary>
    class Schedule
    {
        public string id { get; set; }      // fullDay
        public string name { get; set; }    // Полный день
    }

    /// <summary>
    /// Тип занятости
    /// </summary>
    class Employment
    {
        public string id { get; set; }      // full
        public string name { get; set; }    // Полная занятость
    }





    /// <summary>
    /// Ключевые навыки
    /// </summary>
    class Key_skills
    {
        public string name { get; set; }
    }

    /// <summary>
    /// Регион
    /// </summary>
    class Area
    {
        public string url { get; set; } // https://api.hh.ru/areas/53
        public int id { get; set; }     // 53
        public string name { get; set; } //Краснодар
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
        public string city { get; set; }        //Москва
        public string description { get; set; }
        public string street { get; set; }  // Волгоградский проспект
        public float lat { get; set; }      // 55.709211
        public float lng { get; set; }      // 37.732117
        public string raw { get; set; }
    }

    class Metro
    {
        public string line_name { get; set; }   // Таганско-Краснопресненская
        public float station_id { get; set; }   // 7.139
        public int line_id { get; set; }        // 7
        public float lat { get; set; }          // 55.709211
        public string station_name { get; set; } // Текстильщики
        public float lng { get; set; }          // 37.732117
    }

    class Metro_stations : Metro { }
}
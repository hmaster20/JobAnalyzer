using System;
using System.Collections.Generic;

namespace JobAnalyzer
{
    /// <summary>Класс содержит полные сведения о вакансии</summary>
    public class Vacancy : VacancyGlobal
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
    }

    /// <summary>Работодатель</summary>
    public class Employer
    {
        public SerializableDictionary<string, string> logo_urls { get; set; } // original Ссылка на логотип работодателя https://hhcdn.ru/employer-logo-original/246850.jpg\
        public string vacancies_url { get; set; }   // ссылка на вакансии через API вида https://api.hh.ru/vacancies?employer_id=1733392\
        public string name { get; set; }    // Наименование компании работодателя
        public string url { get; set; }     // ссылка на информацию работодателя через API вида https://api.hh.ru/employers/1733392\
        public string alternate_url { get; set; }   // ссылка на информацию работодателя через HH.ru вида https://hh.ru/employer/1733392\
        public string original { get; set; }
        public int id { get; set; }         // Идентификатор компании
        public bool trusted { get; set; }
    }

    /// <summary>Подразделение</summary>
    public class Department
    {
        public string id { get; set; }      // HH-1455-TECH
        public string name { get; set; }    // HeadHunter::Технический департамент
    }

    /// <summary>Специализация</summary>
    public class Specializations
    {
        public float id { get; set; }
        public string name { get; set; }        // Название: Программирование, Разработка
        public int profarea_id { get; set; }
        public string profarea_name { get; set; }   // Направление: Информационные технологии, интернет, телеком
    }

    /// <summary>
    /// Зарплата
    /// </summary>
    public class Salary
    {
        public string from { get; set; }        // 30000
        public string to { get; set; }          // 35000
        public string currency { get; set; }    // RUR или USD
    }

    /// <summary>
    /// Доступность (открытость) вакансии
    /// </summary>
    public class Type
    {
        public string id { get; set; }      // open
        public string name { get; set; }    // Открытая
    }

    /// <summary>
    /// Требуемый опыт работы в годах
    /// </summary>
    public class Experience
    {
        public string id { get; set; }  // between1And3
        public string name { get; set; }    //"От 1 года до 3 лет
    }

    /// <summary>График работы</summary>
    public class Schedule
    {
        public string id { get; set; }      // fullDay
        public string name { get; set; }    // Полный день

        public override string ToString()
        {
            return name;
        }
    }

    /// <summary>Тип занятости</summary>
    public class Employment
    {
        public string id { get; set; }      // full
        public string name { get; set; }    // Полная занятость
    }


    /// <summary>Ключевые навыки</summary>
    public class Key_skills
    {
        public string name { get; set; }
    }


    /// <summary>Профессиональная область</summary>
    public class Specs
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Specialization> specializations { get; set; }

        public override string ToString()
        {
            return name;
        }

        internal static int CompareByName(Specs a, Specs b)
        {
            return string.Compare(a.name, b.name);
        }
    }

    /// <summary>Профессиональная область - Специализация</summary>
    public class Specialization
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool laboring { get; set; }
    }


    /// <summary>Регион (Страны)</summary>
    public class Area
    {
        public string url { get; set; } // https://api.hh.ru/areas/53
        public int id { get; set; }     // 53
        public string name { get; set; } //Краснодар

        public override string ToString()
        {
            return name;
        }

        public static int CompareByName(Area a, Area b)
        {
            return string.Compare(a.name, b.name);
        }
    }

    /// <summary>Дерево всех регионов</summary>
    public class Areas
    {
        public Areas()
        {
            areas = new List<Areas>();
        }
        public string parent_id { get; set; }
        public List<Areas> areas { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public static int CompareByName(Areas a, Areas b)
        {
            return string.Compare(a.name, b.name);
        }

        public static Areas Find(Areas node, string name)   // Рекурсивный поиск
        {
            if (node == null)
                return null;

            if (node.name == name)
                return node;

            foreach (var child in node.areas)
            {
                var found = Find(child, name);
                if (found != null)
                    return found;
            }

            return null;
        }

        public static Areas FindbyID(Areas node, string id)   // Рекурсивный поиск
        {
            if (node == null)
                return null;

            if (node.id == id)
                return node;

            foreach (var child in node.areas)
            {
                var found = FindbyID(child, id);
                if (found != null)
                    return found;
            }

            return null;
        }
    }

    public class Address
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

    public class Metro
    {
        public string line_name { get; set; }   // Таганско-Краснопресненская
        public float station_id { get; set; }   // 7.139
        public int line_id { get; set; }        // 7
        public float lat { get; set; }          // 55.709211
        public string station_name { get; set; } // Текстильщики
        public float lng { get; set; }          // 37.732117
    }

    public class Metro_stations : Metro { }
}

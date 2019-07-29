using System;
using System.Collections.Generic;

namespace JobAnalyzer.Class.Vacancy
{
    public class BillingType
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Area
    {
        public string id { get; set; }

        /// <summary>
        /// Москва
        /// </summary>
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Salary
    {
        /// <summary>Зарплата от</summary>
        public int? from { get; set; }

        /// <summary>Зарплата до</summary>
        public int? to { get; set; }

        /// <summary>Валюта, например: RUR</summary>
        public string currency { get; set; }
        public bool gross { get; set; }
    }

    public class Type
    {
        /// <summary>
        /// open
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Открытая
        /// </summary>
        public string name { get; set; }
    }

    public class Site
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Experience
    {
        /// <summary>
        /// between3And6
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// От 3 до 6 лет
        /// </summary>
        public string name { get; set; }
    }

    public class Schedule
    {
        /// <summary>
        /// fullDay
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Полный день
        /// </summary>
        public string name { get; set; }
    }

    public class Employment
    {
        /// <summary>
        /// full
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Полная занятость
        /// </summary>
        public string name { get; set; }
    }

    public class Specialization
    {
        /// <summary>
        /// 1.221
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Программирование, Разработка
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        public string profarea_id { get; set; }

        /// <summary>
        /// Информационные технологии, интернет, телеком
        /// </summary>
        public string profarea_name { get; set; }
    }

    public class LogoUrls
    {
        public string original { get; set; }
        public string __invalid_name__90 { get; set; }
        public string __invalid_name__240 { get; set; }
    }

    public class Employer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string alternate_url { get; set; }
        public LogoUrls logo_urls { get; set; }
        public string vacancies_url { get; set; }
        public bool trusted { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public bool premium { get; set; }
        public BillingType billing_type { get; set; }
        public List<object> relations { get; set; }
        public string name { get; set; }
        public object insider_interview { get; set; }
        public bool response_letter_required { get; set; }
        public Area area { get; set; }
        public Salary salary { get; set; }
        public Type type { get; set; }
        public object address { get; set; }
        public bool allow_messages { get; set; }
        public Site site { get; set; }
        public Experience experience { get; set; }
        public Schedule schedule { get; set; }
        public Employment employment { get; set; }
        public object department { get; set; }
        public object contacts { get; set; }
        public string description { get; set; }
        public object branded_description { get; set; }
        public object vacancy_constructor_template { get; set; }
        public List<object> key_skills { get; set; }
        public bool accept_handicapped { get; set; }
        public bool accept_kids { get; set; }
        public bool archived { get; set; }
        public object response_url { get; set; }
        public List<Specialization> specializations { get; set; }
        public object code { get; set; }
        public bool hidden { get; set; }
        public bool quick_responses_allowed { get; set; }
        public List<object> driver_license_types { get; set; }
        public bool accept_incomplete_resumes { get; set; }
        public Employer employer { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public object negotiations_url { get; set; }
        public object suitable_resumes_url { get; set; }
        public string apply_alternate_url { get; set; }
        public bool has_test { get; set; }
        public object test { get; set; }
        public string alternate_url { get; set; }

        public string dgvID { get { return id; } }
        public string dgvNAME { get { return name; } }
        public string dgvDESC { get { return description; } }
        public string dgvDATE { get { return published_at.ToShortDateString(); } }
        public string dgvAREA { get { return area.name; } }
        public string dgvEMPL { get { return employer.name; } }
        public string dgvPriceFrom
        {
            get
            {
                return (salary !=null && salary.from != null) ? salary.from.ToString() : 0.ToString();
            }
        }
        public string dgvPriceTo
        {
            get
            {
                return (salary != null && salary.to != null) ? salary.to.ToString() : 0.ToString();
            }
        }
    }
}
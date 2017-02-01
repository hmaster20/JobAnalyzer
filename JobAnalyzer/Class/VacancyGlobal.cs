using System;

namespace JobAnalyzer
{
    public class VacancyGlobal
    {
        public VacancyGlobal()
        {
            employer = new Employer();
            department = new Department();
            salary = new Salary();
            address = new Address();
            area = new Area();
            type = new Type();
        }     
        public int id { get; set; }         // 19431195
        public string name { get; set; }    // Программист C# junior
        public bool archived { get; set; }
        public bool response_letter_required { get; set; }
        public string alternate_url { get; set; }       // https://hh.ru/vacancy/19431195
        public string apply_alternate_url { get; set; } // https://hh.ru/applicant/vacancy_response?vacancyId=19431195
        public DateTime created_at { get; set; } //"2017-01-30T12:34:37+0300"
        public DateTime published_at { get; set; }//"2017-01-30T12:34:37+0300"
        public Department department { get; set; }
        public Area area { get; set; }
        public Salary salary { get; set; }
        public Employer employer { get; set; }
        public Type type { get; set; }
        public Address address { get; set; }
    }
}
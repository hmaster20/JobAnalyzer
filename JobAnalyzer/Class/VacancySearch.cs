using System;
using System.Collections.Generic;

namespace JobAnalyzer
{
    /// <summary>
    /// Класс обработки найденных вакансий
    /// </summary>
    public class Search
    {
        public Search()
        {
            items = new Items[] { };
        }
        public Items[] items { get; set; }
        public int found { get; set; }      // Найдено вакансий
        public int per_page { get; set; }   // Количество вакансий на странице
        public int page { get; set; }       // Текущая страница
        public int pages { get; set; }      // Всего страниц
    }

    public class Items : VacancyGlobal
    {
        public Items()
        {
            snippet = new Snippet();
        }
        public Snippet snippet { get; set; }
        public bool premium { get; set; }
        public string url { get; set; }                 // https://api.hh.ru/vacancies/19431195?host=hh.ru
    }

    public class Snippet
    {
        public string responsibility { get; set; } // Обязанность : Разработка прикладного программного обеспечения. Участие в командной разработке.
        public string requirement { get; set; } // Требование : Высшее техническое образование. Знание языка программирования <highlighttext>C#</highlighttext>. Опыт разработки c СУБД, знание SQL. Многопоточное программирование. Уверенные знания основных концепций разработки...
    }
}

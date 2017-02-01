using System;
using System.Collections.Generic;

namespace JobAnalyzer
{
    /// <summary>
    /// Класс обработки найденных вакансий
    /// </summary>
    class Search
    {
        public Search()
        {
            items = new Items[] { };
        }
        public Items[] items { get; set; }
        public int per_page { get; set; } // Показывать количество на странице
        public int page { get; set; }      // Текущая страница
        public int pages { get; set; }     // Всего страниц
        public int found { get; set; }      // Найдено вакансий
    }

    class Items : VacancyGlobal
    {
        public Items()
        {
            snippet = new Snippet();         
        }
        public Snippet snippet { get; set; }
        public bool premium { get; set; }
        public string url { get; set; }                 // https://api.hh.ru/vacancies/19431195?host=hh.ru
    }

    class Snippet
    {
        public string responsibility { get; set; } // Обязанность : Разработка прикладного программного обеспечения. Участие в командной разработке.
        public string requirement { get; set; } // Требование : Высшее техническое образование. Знание языка программирования <highlighttext>C#</highlighttext>. Опыт разработки c СУБД, знание SQL. Многопоточное программирование. Уверенные знания основных концепций разработки...
    }  
    
    
       



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




    https://krasnodar.hh.ru/search/vacancy?text=C%23&area=53&salary=&currency_code=RUR&only_with_salary=true&experience=doesNotMatter&order_by=relevance&search_period=&items_on_page=20&no_magic=true

    https://github.com/hhru/api/blob/master/docs/vacancies.md#search


     */
}

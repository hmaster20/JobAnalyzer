using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAnalyzer
{
    class Search
    {
        public Search()
        {
            items = new Items();
        }

        public int per_page { get; set; } // Показывать количество на странице
        public int page { get; set; }      // Текущая страница
        public int pages { get; set; }     // Всего страниц
        public int found { get; set; }      // Найдено вакансий

        public Items items { get; set; }

    }

    class Items
    {

    }

    /*
     * {"clusters":null,"
     * items":[{
     * "salary":{"to":35000,"from":30000,"currency":"RUR"},
     * "snippet":{"requirement":"Высшее техническое образование. Знание языка программирования <highlighttext>C#</highlighttext>. Опыт разработки c СУБД, знание SQL. Многопоточное программирование. Уверенные знания основных концепций разработки...","responsibility":"Разработка прикладного программного обеспечения. Участие в командной разработке."},
     * "archived":false,
     * "premium":false,
     * "name":"Программист C# junior",
     * "area":{"url":"https://api.hh.ru/areas/53","id":"53","name":"Краснодар"},
     * "url":"https://api.hh.ru/vacancies/19431195?host=hh.ru",
     * "created_at":"2017-01-30T12:34:37+0300",
     * "apply_alternate_url":"https://hh.ru/applicant/vacancy_response?vacancyId=19431195",
     * "relations":[],
     * "employer":{
     * "logo_urls":null,
     * "vacancies_url":"https://api.hh.ru/vacancies?employer_id=2657316",
     * "name":"Аура",
     * "url":"https://api.hh.ru/employers/2657316",
     * "alternate_url":"https://hh.ru/employer/2657316",
     * "id":"2657316",
     * "trusted":true},
     * "response_letter_required":false,
     * "published_at":"2017-01-30T12:34:37+0300",
     * "address":{
     * "building":"2/1",
     * "city":"Краснодар",
     * "description":null,
     * "metro":null,
     * "metro_stations":[],
     * "raw":null,
     * "street":"Центральный микрорайон, Железнодорожная улица",
     * "lat":45.020832,
     * "lng":38.98638,
     * "id":"748874"},
     * "department":null,
     * "alternate_url":"https://hh.ru/vacancy/19431195",
     * "type":{"id":"open","name":"Открытая"},"id":"19431195"},
     */



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

﻿using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace JobAnalyzer
{
    class Handler
    {
        VacancyCollection _VacancySearchCollection { get; set; }

        public Handler()
        {
            _VacancySearchCollection = new VacancyCollection();
        }

        public string FindVacancy(string key)
        {
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
             */

            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("https://api.hh.ru/vacancies"
                + "?text=" + key
                + "&area=" + 53
                 + "&search_period=" + 1
                 + "&search_field=name");

            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        Search CollectVac = JsonConvert.DeserializeObject<Search>(line);

                        foreach (var item in CollectVac.items)
                        {
                            _VacancySearchCollection.Add(item);
                        }
                        _VacancySearchCollection.Save();

                        // parsing
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return "";
        }


        public string GetVacancy(string vac)
        {
            if (vac.Length > 0)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.
                    Create("https://api.hh.ru/vacancies/" + vac);
                request.Method = "GET";
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.UserAgent = "JobAnalyzer - .NET Framework Client";

                try
                {
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
                catch (WebException exc)
                {
                    GetErrorDesciption(exc);
                    MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
                }
                catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
                catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
                catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
                catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
                catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
                catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

                return vac;
            }
            else
                return "";
        }

        private static void GetErrorDesciption(WebException exc)
        {
            using (StreamReader stream = new StreamReader(exc.Response.GetResponseStream()))
            {
                string line;
                if ((line = stream.ReadLine()) != null)
                {
                    Err translation = JsonConvert.DeserializeObject<Err>(line);
                }
            }
        }




        public List<Area> GetCountry()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/areas/countries");
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";

  
            List<Area> ar = new List<Area>();


            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        //"[{\"url\":\"https://api.hh.ru/areas/113\",\"id\":\"113\",\"name\":\"Россия\"},{\"url\":\"https://api.hh.ru/areas/2112\",\"id\":\"2112\",\"name\":\"Абхазия\"},{\"url\":\"https://api.hh.ru/areas/5\",\"id\":\"5\",\"name\":\"Украина\"},{\"url\":\"https://api.hh.ru/areas/6\",\"id\":\"6\",\"name\":\"Австралия\"},{\"url\":\"https://api.hh.ru/areas/40\",\"id\":\"40\",\"name\":\"Казахстан\"},{\"url\":\"https://api.hh.ru/areas/7\",\"id\":\"7\",\"name\":\"Австрия\"},{\"url\":\"https://api.hh.ru/areas/9\",\"id\":\"9\",\"name\":\"Азербайджан\"},{\"url\":\"https://api.hh.ru/areas/2357\",\"id\":\"2357\",\"name\":\"Албания\"},{\"url\":\"https://api.hh.ru/areas/16\",\"id\":\"16\",\"name\":\"Беларусь\"},{\"url\":\"https://api.hh.ru/areas/2368\",\"id\":\"2368\",\"name\":\"Алжир\"},{\"url\":\"https://api.hh.ru/areas/2376\",\"id\":\"2376\",\"name\":\"Ангола\"},{\"url\":\"https://api.hh.ru/areas/2354\",\"id\":\"2354\",\"name\":\"Андорра\"},{\"url\":\"https://api.hh.ru/areas/235\",\"id\":\"235\",\"name\":\"Аргентина\"},{\"url\":\"https://api.hh.ru/areas/13\",\"id\":\"13\",\"name\":\"Армения\"},{\"url\":\"https://api.hh.ru/areas/2110\",\"id\":\"2110\",\"name\":\"Афганистан\"},{\"url\":\"https://api.hh.ru/areas/303\",\"id\":\"303\",\"name\":\"Бангладеш\"},{\"url\":\"https://api.hh.ru/areas/2361\",\"id\":\"2361\",\"name\":\"Бахрейн\"},{\"url\":\"https://api.hh.ru/areas/5047\",\"id\":\"5047\",\"name\":\"Белиз\"},{\"url\":\"https://api.hh.ru/areas/18\",\"id\":\"18\",\"name\":\"Бельгия\"},{\"url\":\"https://api.hh.ru/areas/200\",\"id\":\"200\",\"name\":\"Болгария\"},{\"url\":\"https://api.hh.ru/areas/2228\",\"id\":\"2228\",\"name\":\"Боливия\"},{\"url\":\"https://api.hh.ru/areas/2358\",\"id\":\"2358\",\"name\":\"Босния и Герцеговина\"},{\"url\":\"https://api.hh.ru/areas/243\",\"id\":\"243\",\"name\":\"Бразилия\"},{\"url\":\"https://api.hh.ru/areas/306\",\"id\":\"306\",\"name\":\"Буркина Фасо\"},{\"url\":\"https://api.hh.ru/areas/21\",\"id\":\"21\",\"name\":\"Великобритания\"},{\"url\":\"https://api.hh.ru/areas/114\",\"id\":\"114\",\"name\":\"Венгрия\"},{\"url\":\"https://api.hh.ru/areas/2371\",\"id\":\"2371\",\"name\":\"Венесуэла\"},{\"url\":\"https://api.hh.ru/areas/203\",\"id\":\"203\",\"name\":\"Вьетнам\"},{\"url\":\"https://api.hh.ru/areas/2586\",\"id\":\"2586\",\"name\":\"Габон\"},{\"url\":\"https://api.hh.ru/areas/202\",\"id\":\"202\",\"name\":\"Гвинея\"},{\"url\":\"https://api.hh.ru/areas/27\",\"id\":\"27\",\"name\":\"Германия\"},{\"url\":\"https://api.hh.ru/areas/2435\",\"id\":\"2435\",\"name\":\"Государство Палестина\"},{\"url\":\"https://api.hh.ru/areas/213\",\"id\":\"213\",\"name\":\"Греция\"},{\"url\":\"https://api.hh.ru/areas/28\",\"id\":\"28\",\"name\":\"Грузия\"},{\"url\":\"https://api.hh.ru/areas/30\",\"id\":\"30\",\"name\":\"Дания\"},{\"url\":\"https://api.hh.ru/areas/311\",\"id\":\"311\",\"name\":\"Демократическая Республика Конго\"},{\"url\":\"https://api.hh.ru/areas/2730\",\"id\":\"2730\",\"name\":\"Доминиканская Республика\"},{\"url\":\"https://api.hh.ru/areas/305\",\"id\":\"305\",\"name\":\"Египет\"},{\"url\":\"https://api.hh.ru/areas/33\",\"id\":\"33\",\"name\":\"Израиль\"},{\"url\":\"https://api.hh.ru/areas/209\",\"id\":\"209\",\"name\":\"Индия\"},{\"url\":\"https://api.hh.ru/areas/2108\",\"id\":\"2108\",\"name\":\"Индонезия\"},{\"url\":\"https://api.hh.ru/areas/2365\",\"id\":\"2365\",\"name\":\"Иордания\"},{\"url\":\"https://api.hh.ru/areas/2232\",\"id\":\"2232\",\"name\":\"Ирак\"},{\"url\":\"https://api.hh.ru/areas/2227\",\"id\":\"2227\",\"name\":\"Иран\"},{\"url\":\"https://api.hh.ru/areas/36\",\"id\":\"36\",\"name\":\"Ирландия\"},{\"url\":\"https://api.hh.ru/areas/302\",\"id\":\"302\",\"name\":\"Исландия\"},{\"url\":\"https://api.hh.ru/areas/37\",\"id\":\"37\",\"name\":\"Испания\"},{\"url\":\"https://api.hh.ru/areas/38\",\"id\":\"38\",\"name\":\"Италия\"},{\"url\":\"https://api.hh.ru/areas/2109\",\"id\":\"2109\",\"name\":\"Йемен\"},{\"url\":\"https://api.hh.ru/areas/245\",\"id\":\"245\",\"name\":\"Камбоджа\"},{\"url\":\"https://api.hh.ru/areas/45\",\"id\":\"45\",\"name\":\"Канада\"},{\"url\":\"https://api.hh.ru/areas/210\",\"id\":\"210\",\"name\":\"Катар\"},{\"url\":\"https://api.hh.ru/areas/236\",\"id\":\"236\",\"name\":\"Кипр\"},{\"url\":\"https://api.hh.ru/areas/50\",\"id\":\"50\",\"name\":\"Китай\"},{\"url\":\"https://api.hh.ru/areas/2113\",\"id\":\"2113\",\"name\":\"Колумбия\"},{\"url\":\"https://api.hh.ru/areas/2380\",\"id\":\"2380\",\"name\":\"Кооперативная Республика Гайана\"},{\"url\":\"https://api.hh.ru/areas/2362\",\"id\":\"2362\",\"name\":\"Королевство Саудовская Аравия\"},{\"url\":\"https://api.hh.ru/areas/2363\",\"id\":\"2363\",\"name\":\"Кувейт\"},{\"url\":\"https://api.hh.ru/areas/57\",\"id\":\"57\",\"name\":\"Латвия\"},{\"url\":\"https://api.hh.ru/areas/48\",\"id\":\"48\",\"name\":\"Кыргызстан\"},{\"url\":\"https://api.hh.ru/areas/2111\",\"id\":\"2111\",\"name\":\"Ливан\"},{\"url\":\"https://api.hh.ru/areas/2106\",\"id\":\"2106\",\"name\":\"Ливия\"},{\"url\":\"https://api.hh.ru/areas/59\",\"id\":\"59\",\"name\":\"Литва\"},{\"url\":\"https://api.hh.ru/areas/2355\",\"id\":\"2355\",\"name\":\"Лихтенштейн\"},{\"url\":\"https://api.hh.ru/areas/206\",\"id\":\"206\",\"name\":\"Люксембург\"},{\"url\":\"https://api.hh.ru/areas/2359\",\"id\":\"2359\",\"name\":\"Македония\"},{\"url\":\"https://api.hh.ru/areas/238\",\"id\":\"238\",\"name\":\"Малайзия\"},{\"url\":\"https://api.hh.ru/areas/2798\",\"id\":\"2798\",\"name\":\"Мальдивская Республика\"},{\"url\":\"https://api.hh.ru/areas/2353\",\"id\":\"2353\",\"name\":\"Мальта\"},{\"url\":\"https://api.hh.ru/areas/2372\",\"id\":\"2372\",\"name\":\"Марокко\"},{\"url\":\"https://api.hh.ru/areas/2229\",\"id\":\"2229\",\"name\":\"Мексика\"},{\"url\":\"https://api.hh.ru/areas/62\",\"id\":\"62\",\"name\":\"Молдавия\"},{\"url\":\"https://api.hh.ru/areas/2356\",\"id\":\"2356\",\"name\":\"Монако\"},{\"url\":\"https://api.hh.ru/areas/2231\",\"id\":\"2231\",\"name\":\"Монголия\"},{\"url\":\"https://api.hh.ru/areas/2487\",\"id\":\"2487\",\"name\":\"Мьянма\"},{\"url\":\"https://api.hh.ru/areas/2375\",\"id\":\"2375\",\"name\":\"Намибия\"},{\"url\":\"https://api.hh.ru/areas/240\",\"id\":\"240\",\"name\":\"Нигерия\"},{\"url\":\"https://api.hh.ru/areas/65\",\"id\":\"65\",\"name\":\"Нидерланды\"},{\"url\":\"https://api.hh.ru/areas/204\",\"id\":\"204\",\"name\":\"Новая Зеландия\"},{\"url\":\"https://api.hh.ru/areas/207\",\"id\":\"207\",\"name\":\"Норвегия\"},{\"url\":\"https://api.hh.ru/areas/208\",\"id\":\"208\",\"name\":\"ОАЭ\"},{\"url\":\"https://api.hh.ru/areas/2364\",\"id\":\"2364\",\"name\":\"Оман\"},{\"url\":\"https://api.hh.ru/areas/316\",\"id\":\"316\",\"name\":\"Пакистан\"},{\"url\":\"https://api.hh.ru/areas/2587\",\"id\":\"2587\",\"name\":\"Панама\"},{\"url\":\"https://api.hh.ru/areas/2395\",\"id\":\"2395\",\"name\":\"Перу\"},{\"url\":\"https://api.hh.ru/areas/74\",\"id\":\"74\",\"name\":\"Польша\"},{\"url\":\"https://api.hh.ru/areas/241\",\"id\":\"241\",\"name\":\"Португалия\"},{\"url\":\"https://api.hh.ru/areas/2752\",\"id\":\"2752\",\"name\":\"Республика Бенин\"},{\"url\":\"https://api.hh.ru/areas/2491\",\"id\":\"2491\",\"name\":\"Республика Гана\"},{\"url\":\"https://api.hh.ru/areas/2504\",\"id\":\"2504\",\"name\":\"Республика Зимбабве\"},{\"url\":\"https://api.hh.ru/areas/2669\",\"id\":\"2669\",\"name\":\"Республика Камерун\"},{\"url\":\"https://api.hh.ru/areas/2453\",\"id\":\"2453\",\"name\":\"Республика Кения\"},{\"url\":\"https://api.hh.ru/areas/312\",\"id\":\"312\",\"name\":\"Республика Конго\"},{\"url\":\"https://api.hh.ru/areas/2636\",\"id\":\"2636\",\"name\":\"Республика Коста-Рика\"},{\"url\":\"https://api.hh.ru/areas/2454\",\"id\":\"2454\",\"name\":\"Республика Кот-д’Ивуар\"},{\"url\":\"https://api.hh.ru/areas/2635\",\"id\":\"2635\",\"name\":\"Республика Куба\"},{\"url\":\"https://api.hh.ru/areas/2398\",\"id\":\"2398\",\"name\":\"Республика Либерия\"},{\"url\":\"https://api.hh.ru/areas/2370\",\"id\":\"2370\",\"name\":\"Республика Маврикий\"},{\"url\":\"https://api.hh.ru/areas/2488\",\"id\":\"2488\",\"name\":\"Республика Мадагаскар\"},{\"url\":\"https://api.hh.ru/areas/2378\",\"id\":\"2378\",\"name\":\"Республика Нигер\"},{\"url\":\"https://api.hh.ru/areas/3666\",\"id\":\"3666\",\"name\":\"Республика Никарагуа\"},{\"url\":\"https://api.hh.ru/areas/2446\",\"id\":\"2446\",\"name\":\"Республика Северный Судан\"},{\"url\":\"https://api.hh.ru/areas/2367\",\"id\":\"2367\",\"name\":\"Республика Сейшельские острова\"},{\"url\":\"https://api.hh.ru/areas/2374\",\"id\":\"2374\",\"name\":\"Республика Сенегал\"},{\"url\":\"https://api.hh.ru/areas/2369\",\"id\":\"2369\",\"name\":\"Реюньон\"},{\"url\":\"https://api.hh.ru/areas/234\",\"id\":\"234\",\"name\":\"Румыния\"},{\"url\":\"https://api.hh.ru/areas/5048\",\"id\":\"5048\",\"name\":\"Сент-Винсент и Гренадины\"},{\"url\":\"https://api.hh.ru/areas/146\",\"id\":\"146\",\"name\":\"Сербия\"},{\"url\":\"https://api.hh.ru/areas/233\",\"id\":\"233\",\"name\":\"Сингапур\"},{\"url\":\"https://api.hh.ru/areas/317\",\"id\":\"317\",\"name\":\"Сирия\"},{\"url\":\"https://api.hh.ru/areas/318\",\"id\":\"318\",\"name\":\"Словакия\"},{\"url\":\"https://api.hh.ru/areas/2105\",\"id\":\"2105\",\"name\":\"Словения\"},{\"url\":\"https://api.hh.ru/areas/85\",\"id\":\"85\",\"name\":\"США\"},{\"url\":\"https://api.hh.ru/areas/86\",\"id\":\"86\",\"name\":\"Таджикистан\"},{\"url\":\"https://api.hh.ru/areas/300\",\"id\":\"300\",\"name\":\"Таиланд\"},{\"url\":\"https://api.hh.ru/areas/148\",\"id\":\"148\",\"name\":\"Тайвань\"},{\"url\":\"https://api.hh.ru/areas/244\",\"id\":\"244\",\"name\":\"Тунис\"},{\"url\":\"https://api.hh.ru/areas/93\",\"id\":\"93\",\"name\":\"Туркменистан\"},{\"url\":\"https://api.hh.ru/areas/97\",\"id\":\"97\",\"name\":\"Узбекистан\"},{\"url\":\"https://api.hh.ru/areas/94\",\"id\":\"94\",\"name\":\"Турция\"},{\"url\":\"https://api.hh.ru/areas/4635\",\"id\":\"4635\",\"name\":\"Уганда\"},{\"url\":\"https://api.hh.ru/areas/2810\",\"id\":\"2810\",\"name\":\"Уругвай\"},{\"url\":\"https://api.hh.ru/areas/2360\",\"id\":\"2360\",\"name\":\"Филиппины\"},{\"url\":\"https://api.hh.ru/areas/100\",\"id\":\"100\",\"name\":\"Финляндия\"},{\"url\":\"https://api.hh.ru/areas/101\",\"id\":\"101\",\"name\":\"Франция\"},{\"url\":\"https://api.hh.ru/areas/2103\",\"id\":\"2103\",\"name\":\"Хорватия\"},{\"url\":\"https://api.hh.ru/areas/5046\",\"id\":\"5046\",\"name\":\"Черногория\"},{\"url\":\"https://api.hh.ru/areas/199\",\"id\":\"199\",\"name\":\"Чехия\"},{\"url\":\"https://api.hh.ru/areas/2396\",\"id\":\"2396\",\"name\":\"Чили\"},{\"url\":\"https://api.hh.ru/areas/108\",\"id\":\"108\",\"name\":\"Швейцария\"},{\"url\":\"https://api.hh.ru/areas/149\",\"id\":\"149\",\"name\":\"Швеция\"},{\"url\":\"https://api.hh.ru/areas/239\",\"id\":\"239\",\"name\":\"Шотландия\"},{\"url\":\"https://api.hh.ru/areas/2511\",\"id\":\"2511\",\"name\":\"Шри-Ланка\"},{\"url\":\"https://api.hh.ru/areas/242\",\"id\":\"242\",\"name\":\"Эквадор\"},{\"url\":\"https://api.hh.ru/areas/109\",\"id\":\"109\",\"name\":\"Эстония\"},{\"url\":\"https://api.hh.ru/areas/2520\",\"id\":\"2520\",\"name\":\"Эфиопия\"},{\"url\":\"https://api.hh.ru/areas/211\",\"id\":\"211\",\"name\":\"ЮАР\"},{\"url\":\"https://api.hh.ru/areas/110\",\"id\":\"110\",\"name\":\"Южная Корея\"},{\"url\":\"https://api.hh.ru/areas/2524\",\"id\":\"2524\",\"name\":\"Южная Осетия\"},{\"url\":\"https://api.hh.ru/areas/2440\",\"id\":\"2440\",\"name\":\"Ямайка\"},{\"url\":\"https://api.hh.ru/areas/111\",\"id\":\"111\",\"name\":\"Япония\"}]"
                        // Cannot deserialize the current JSON array (e.g. [1,2,3]) into type 'JobAnalyzer.TestArr' because the type requires a JSON object (e.g. {"name":"value"}) to deserialize correctly.
                        // To fix this error either change the JSON to a JSON object (e.g. { "name":"value"}) or change the deserialized type to an array or a type that implements a collection interface (e.g.ICollection, IList) like List<T> that can be deserialized from a JSON array. JsonArrayAttribute can also be added to the type to force it to deserialize from a JSON array.
                        //Path '', line 1, position 1.


                        List<Area> CollectVac = JsonConvert.DeserializeObject<List<Area>>(line);

                        foreach (var item in CollectVac)
                        {
                            ar.Add(item);
                        }
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            return ar;
        }



        public void GetArrr()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.hh.ru/areas/113");
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "JobAnalyzer - .NET Framework Client";


            List<Area> ar = new List<Area>();


            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {

                        List<Area> CollectVac = JsonConvert.DeserializeObject<List<Area>>(line);

                        foreach (var item in CollectVac)
                        {
                            ar.Add(item);
                        }
                    }
                }
            }
            catch (WebException exc)
            {
                GetErrorDesciption(exc);
                MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status);
            }
            catch (ProtocolViolationException exc) { MessageBox.Show("Протокольная ошибка: " + exc.Message); }
            catch (UriFormatException exc) { MessageBox.Show("Ошибка формата URI: " + exc.Message); }
            catch (NotSupportedException exc) { MessageBox.Show("Неизвестный протокол: " + exc.Message); }
            catch (IOException exc) { MessageBox.Show("Ошибка ввода-вывода: " + exc.Message); }
            catch (System.Security.SecurityException exc) { MessageBox.Show("Исключение в связи с нарушением безопасности: " + exc.Message); }
            catch (InvalidOperationException exc) { MessageBox.Show("Недопустимая операция: " + exc.Message); }

            //return ar;
        }

    }
}


//https://msdn.microsoft.com/ru-ru/library/456dfw4f(v=vs.110).aspx


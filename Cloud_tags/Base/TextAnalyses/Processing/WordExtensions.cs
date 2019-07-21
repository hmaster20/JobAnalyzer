using System;
using System.Collections.Generic;
using System.Linq;
using Gma.CodeCloud.Base.TextAnalyses.Blacklist;
using Gma.CodeCloud.Base.TextAnalyses.Stemmers;

namespace Gma.CodeCloud.Base.TextAnalyses.Processing
{
    public static class WordExtensions
    {
        public static IEnumerable<WordGroup> GroupByStem(this IEnumerable<IWord> words, IWordStemmer stemmer)
        {
            return
                words.GroupBy(
                    word => stemmer.GetStem(word.Text), 
                    (stam, sameStamWords) => new WordGroup(stam, sameStamWords));
            
        }

        /// <summary>Сортировка слов</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="words"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> SortByOccurences<T>(this IEnumerable<T> words) where T : IWord
        {
            return 
                words.OrderByDescending(
                    word => word.Occurrences);
        }

        /// <summary>Считает количество вхождений каждого слова</summary>
        /// <param name="terms">Список слов</param>
        /// <returns></returns>
        public static IEnumerable<IWord> CountOccurences(this IEnumerable<string> terms)
        {
            return 
                terms.GroupBy(
                    term => term,
                    (term, equivalentTerms) => new Word(term, equivalentTerms.Count()), 
                    StringComparer.InvariantCultureIgnoreCase)
                    .Cast<IWord>();
        }

        /// <summary>Убирает слова, если они есть в фильтре</summary>
        /// <param name="terms"></param>
        /// <param name="blacklist"></param>
        /// <returns></returns>
        public static IEnumerable<string> Filter(this IEnumerable<string> terms, IBlacklist blacklist)
        {
            return
                terms.Where(
                    term => !blacklist.Countains(term));
        }
    }
}
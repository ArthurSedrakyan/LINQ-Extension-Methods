using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    public static class MyLINQLibrary
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return new EnumForSelect<TSource, TResult>(source.GetEnumerator(), selector);
        }

        public static IEnumerable<TSource> MyWhere<TSource>
            (this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
            
        }


        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, List<TSource>>();

            foreach (var item in source)
            {
                var key = keySelector(item);
                if (dict.Keys.Contains(key))
                {
                    dict[key].Add(item);
                }
                else
                {
                    dict.Add(key, new List<TSource> { item });
                }
            }

            foreach (var item in dict)
            {
                yield return new MyIGrouping<TKey, TSource>(item.Value, item.Key);
            }
        }


        public static List<TSource> MyToList<TSource>(this IEnumerable<TSource> source)
        {
            List<TSource> result = new List<TSource>();
            foreach (TSource item in source)
            {
                result.Add(item);
            }
            return result;
        }


        public static Dictionary<TKey, TSource> MyToDictionary<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Dictionary<TKey, TSource> result = new Dictionary<TKey, TSource>();
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                try
                {
                    result.Add(key, item);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("There is a Key with same name");
                    continue;
                }
               
            }
            return result;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    class MyIGrouping<TKey, TSource> :  IGrouping<TKey, TSource>
    {

        IEnumerable<TSource> source;
        TKey key;

        public MyIGrouping(IEnumerable<TSource> source, TKey keySelector)
        {
            this.source = source;
            this.key = keySelector;
        }

        public TKey Key => key;

        public IEnumerator<TSource> GetEnumerator()
        {
            return source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

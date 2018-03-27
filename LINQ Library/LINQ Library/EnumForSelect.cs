using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    class EnumForSelect<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
    {
        IEnumerator<TSource> sources;
        Func<TSource, TResult> selector;

        public EnumForSelect(IEnumerator<TSource> sources,Func<TSource,TResult> selector)
        {
            this.sources = sources;
            this.selector = selector;

        }

        public TResult Current => selector(sources.Current);

        object IEnumerator.Current => sources.Current;

        public void Dispose()
        {
            this.sources.Dispose();
        }
        public IEnumerator<TResult> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            return this.sources.MoveNext();
        }

        public void Reset()
        {
            this.sources.Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}

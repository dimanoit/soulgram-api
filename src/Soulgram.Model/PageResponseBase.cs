using System.Collections.Generic;

namespace Soulgram.Model
{
    public abstract class PageResponseBase<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}

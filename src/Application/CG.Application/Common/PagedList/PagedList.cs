using System.Collections.Generic;

namespace CG.Application.Common.PagedList
{
    public class PagedList<T> 
    {
        public long TotalItems { get; }

        public IEnumerable<T> Results { get; }

        public PagedList(IEnumerable<T> results, long totalItems)
        {
            Results = results;
            TotalItems = totalItems;
        }
    }
}
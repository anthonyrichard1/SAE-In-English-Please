using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public class PageResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public long TotalCount { get; set; }

        public PageResponse(IEnumerable<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}

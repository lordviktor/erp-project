#region Using

using System.Collections.Generic;

#endregion

namespace ERP.Domain.Util
{
    public class PaginatedResult<T>
    {
        public int Count { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
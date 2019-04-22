using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.Pager
{
    public class Pager<T> : BasePager<T>
    {
        public Pager(IQueryable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount) : base(pageIndex, pageSize, totalItemCount)
        {
            Slicedset.AddRange(currentPageItems);
        }
    }
}

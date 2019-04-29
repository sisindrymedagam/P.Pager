using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.Pager
{
    public class Pager<T> : BasePager<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pager{T}"/> class that divides the supplied parent into childs the size of the supplied pageSize.
        /// </summary>
        /// <param name="currentPageItems">A single child that is divided from parent list.</param>
        /// <param name="pageIndex">Index of child set within the parent list.</param>
        /// <param name="pageSize">Size of individual child set.</param>
        /// <param name="totalItemCount">Total number of items in parent list.</param>
        public Pager(IQueryable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount) : base(pageIndex, pageSize, totalItemCount)
        {
            Childset.AddRange(currentPageItems);
        }
    }
}

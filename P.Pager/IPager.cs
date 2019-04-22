using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P.Pager
{
    public interface IPager
    {
        int CurrentPageIndex { get; set; }

        int PageSize { get; set; }

        int TotalItemCount { get; set; }

        int TotalPageCount { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }

        int StartItemIndex { get; }

        int EndItemIndex { get; }
    }

    public interface IPager<out T> : IEnumerable<T>, IPager
    {
        T this[int index] { get; }
    }
}

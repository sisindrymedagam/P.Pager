using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P.Pager
{
    public abstract class BasePager<T> : IPager<T>
    {
        protected readonly List<T> Slicedset = new List<T>();

        protected internal BasePager()
        {
        }

        protected internal BasePager(int pageIndex, int pageSize, int totalItemCount)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException($"pageNumber = {pageIndex}. PageNumber cannot be less than 1.");
            }

            if (pageSize < 0)
            {
                throw new ArgumentOutOfRangeException($"pageSize = {pageSize}. PageSize cannot be less than 1.");
            }

            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }

        public bool HasPreviousPage { get { return CurrentPageIndex > 1; } }

        public bool HasNextPage { get { return CurrentPageIndex < TotalPageCount; } }

        public bool IsFirstPage { get { return CurrentPageIndex == 1; } }

        public bool IsLastPage { get { return CurrentPageIndex == TotalPageCount; } }

        public int StartItemIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

        public int EndItemIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }

        public IEnumerator<T> GetEnumerator()
        {
            return Slicedset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index] => Slicedset[index];
    }
}

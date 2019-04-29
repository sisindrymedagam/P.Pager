using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P.Pager
{
    /// <summary>
    /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
    /// </summary>
    public interface IPager
    {
        /// <summary>
        /// Index of child set within the parent list.
        /// </summary>
        int CurrentPageIndex { get; set; }

        /// <summary>
        /// Size of individual child set.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Total number of items in parent list.
        /// </summary>
        int TotalItemCount { get; set; }

        /// <summary>
        /// Total number of child sets in parent list.
        /// </summary>
        int TotalPageCount { get; }

        /// <summary>
        /// Returns true if this is not first child.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Returns true if this is not the last child.
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// Returns true if this is the first child.
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Returns true if this is the last child.
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// Sub-index of first item in paged child.
        /// </summary>
        int StartItemIndex { get; }

        /// <summary>
        /// Sub-index of last item in paged child.
        /// </summary>
        int EndItemIndex { get; }
    }

    /// <summary>
    /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
    /// </summary>
    /// <typeparam name="T">The type of object the collection should contain.</typeparam>
    public interface IPager<out T> : IEnumerable<T>, IPager
    {
        T this[int index] { get; }
    }
}

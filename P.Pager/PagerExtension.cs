using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.Pager
{
    public static class PagerExtension
    {
        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list.</param>
        /// <param name="pageSize">Size of individual child.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static IPager<T> AsPagerList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var totalItemCount = allItems.Count();
            while (totalItemCount <= itemIndex && pageIndex > 1)
            {
                itemIndex = (--pageIndex - 1) * pageSize;
            }
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize);
            return new Pager<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
        }

        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list. By default 1.</param>
        /// <param name="pageSize">Size of individual child. By default 10.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static IPager<T> ToPagerList<T>(this IEnumerable<T> allItems, int pageIndex = 1, int pageSize = 10)
        {
            return allItems.AsQueryable().AsPagerList(pageIndex, pageSize);
        }

        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list. By default 1.</param>
        /// <param name="pageSize">Size of individual child. By default 10.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static IPager<T> ToPagerList<T>(this IQueryable<T> allItems, int pageIndex = 1, int pageSize = 10)
        {
            return allItems.AsPagerList(pageIndex, pageSize);
        }
    }
}

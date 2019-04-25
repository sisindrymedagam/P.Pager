using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        /// <param name="pageIndex">Index of child set within the parent list.</param>
        /// <param name="pageSize">Size of individual child.</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        private static async Task<IPager<T>> AsPagerListAsync<T>(IQueryable<T> allItems, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var childSet = new List<T>();
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var totalItemCount = allItems.Count();
            while (totalItemCount <= itemIndex && pageIndex > 1)
            {
                itemIndex = (--pageIndex - 1) * pageSize;
            }
            childSet.AddRange(await allItems.Skip(itemIndex).Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false));
            return new PagerAsync<T>(childSet, pageIndex, pageSize, totalItemCount);
        }

        /// <summary>
        /// Async creates a child set of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static async Task<List<T>> ToListAsync<T>(this IEnumerable<T> allItems, CancellationToken cancellationToken)
        {
            return await Task.Run(() => allItems.ToList(), cancellationToken);
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

        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list. By default 1.</param>
        /// <param name="pageSize">Size of individual child. By default 10.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static async Task<IPager<T>> ToPagerListAsync<T>(this IEnumerable<T> allItems, int? pageIndex, int pageSize = 10)
        {
            return await AsPagerListAsync(allItems.AsQueryable(), pageIndex ?? 1, pageSize, CancellationToken.None);
        }

        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list. By default 1.</param>
        /// <param name="pageSize">Size of individual child. By default 10.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static async Task<IPager<T>> ToPagerListAsync<T>(this IEnumerable<T> allItems, int? pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await AsPagerListAsync(allItems.AsQueryable(), pageIndex ?? 1, pageSize, cancellationToken);
        }

        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list. By default 1.</param>
        /// <param name="pageSize">Size of individual child. By default 10.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static async Task<IPager<T>> ToPagerListAsync<T>(this IQueryable<T> allItems, int? pageIndex, int pageSize)
        {
            return await AsPagerListAsync(allItems, pageIndex ?? 1, pageSize, CancellationToken.None);
        }

        /// <summary>
        /// Represents a child set of a collection of objects that can be individually accessed by index and containing metadata about the parent collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="allItems">Parent that is divided in to children.</param>
        /// <param name="pageIndex">Index of child set within the parent list. By default 1.</param>
        /// <param name="pageSize">Size of individual child.</param>
        /// <returns>Child set that is divided from parent list.</returns>
        public static async Task<IPager<T>> ToPagerListAsync<T>(this IQueryable<T> allItems, int? pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await AsPagerListAsync(allItems, pageIndex ?? 1, pageSize, cancellationToken);
        }

    }
}

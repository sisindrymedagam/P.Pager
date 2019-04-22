using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.Pager
{
    public static class PagerExtension
    {
        public static IPager<T> AsPagedList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
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

        public static IPager<T> ToPagedList<T>(this IEnumerable<T> allItems, int pageIndex = 1, int pageSize = 10)
        {
            return allItems.AsQueryable().AsPagedList(pageIndex, pageSize);
        }

        public static IPager<T> ToPagedList<T>(this IQueryable<T> allItems, int pageIndex = 1, int pageSize = 10)
        {
            return allItems.AsPagedList(pageIndex, pageSize);
        }
    }
}

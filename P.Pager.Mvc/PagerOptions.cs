using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Pager.Mvc
{
    public class PagerOptions
    {
        /// <summary>
        /// Default options for rendering pagination.
        /// </summary>
        public PagerOptions()
        {
            PagesToDisplay = 5;
            HasIndividualPages = true;
            TextToIndividualPages = "{0}";
            TextForDelimiter = null;
            HasEllipses = true;
            EllipsesFormat = "&#8230;";
            TextToFirstPage = "<<";
            TextToPreviousPage = "<";
            TextToNextPage = ">";
            TextToLastPage = ">>";
            ClassToPagerContainer = "container";
            ClassToUl = "pagination";
            ClassToLi = "page-item";
            PageClass = "page-link";
            ClassToActiveLi = "active";
            HasPagerText = false;
            PagerTextFormat = "Page {0} of {1}.";
            HasEntriesText = false;
            EntriesTextFormat = "Showing {0} to {1} of {2} entries.";
        }

        /// <summary>
        /// How many page numbers to display in pagination, by default it is 5.
        /// </summary>
        public int? PagesToDisplay { get; set; }

        /// <summary>
        /// Displays all pages, by default it shows 5 pages.
        /// </summary>
        /// <example>
        /// &lt; 1 2 3 4 5 &gt;
        /// &lt; 4 5 6 7 8 &gt;
        /// </example>
        public bool HasIndividualPages { get; set; }

        /// <summary>
        /// A formatted text to show to show inside the hyperlink. Use {0} to refer page number, by default it is set to {0}
        /// </summary>
        /// <example>
        /// page-{0}
        /// page{0}
        /// </example>
        public string TextToIndividualPages { get; set; }

        /// <summary>
        /// This will appear between each page number. If null or white space, no delimeter will display.
        /// </summary>
        public string TextForDelimiter { get; set; }

        /// <summary>
        /// Adds an ellipe when all page numbers are not displaying, by default it is true.
        /// </summary>
        public bool HasEllipses { get; set; }

        /// <summary>
        /// A formatted text shows when all pages are not displaying, by default it is &#8230;
        /// </summary>
        public string EllipsesFormat { get; set; }

        /// <summary>
        /// A formatted text to show for firstpage link, by default it is set to &lt;&lt;.
        /// </summary>
        public string TextToFirstPage { get; set; }

        /// <summary>
        /// A formatted text to show for previous page link, by default it is set to &lt;.
        /// </summary>
        public string TextToPreviousPage { get; set; }

        /// <summary>
        /// A formatted text to show for next page link, by default it is set to &gt;.
        /// </summary>
        public string TextToNextPage { get; set; }

        /// <summary>
        /// A formatted text to show for last page link, by default it is set to &gt;&gt;.
        /// </summary>
        public string TextToLastPage { get; set; }

        /// <summary>
        /// Css class to append to &lt;div&gt; element in the paging content, by default it is set to pager container.
        /// </summary>
        public string ClassToPagerContainer { get; set; }

        /// <summary>
        /// Css class to append to &lt;ul&gt; element in the paging content, by default it is set to pagination.
        /// </summary>
        public string ClassToUl { get; set; }

        /// <summary>
        /// Css class to append to &lt;li&gt; element in the paging content, by default it is set to page-item.
        /// </summary>
        public string ClassToLi { get; set; }

        /// <summary>
        /// Css class to append to &lt;a&gt;/&lt;span&gt; element in the paging content, by default it is set to page-link.
        /// </summary>
        public string PageClass { get; set; }

        /// <summary>
        /// Css class to append to &lt;li&gt; element if active in the paging content, by default it is set to active.
        /// </summary>
        public string ClassToActiveLi { get; set; }

        /// <summary>
        /// Displaying current page number and total number of pages in pager, by default it is set to false.
        /// </summary>
        /// <example>
        /// Page 10 of 20.
        /// </example>
        public bool HasPagerText { get; set; }

        /// <summary>
        /// Text format will display if HasPagerText is true. Use {0} to refer the current page and {0} to refer total number of pages, by default it is set to Page {0} of {1}.
        /// </summary>
        /// <example>
        /// Page 10 of 20.
        /// </example>
        public string PagerTextFormat { get; set; }

        /// <summary>
        /// Displaying start item, last item and total entries in pager, by default it is set to false.
        /// </summary>
        /// <example>
        /// Showing 1 to 10 of 30 entries.
        /// </example>
        public bool HasEntriesText { get; set; }

        /// <summary>
        /// Text format will display if HasEntriesText is true. {0} refers first entry on page, {1} refers last item on page and {2} refers total number of entries, by default it is set to Showing {0} to {1} of {2} entries.
        /// </summary>
        /// <example>
        /// Showing 1 to 10 of 30 entries.
        /// </example>
        public string EntriesTextFormat { get; set; }

    }
}

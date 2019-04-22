using System;
using System.Collections.Generic;
using System.Text;

namespace P.Pager.Mvc.Core
{
    public class PagerOptions
    {
        public PagerOptions()
        {
            PagerType = PagerTypeEnum.Minimal;
            MaximumPageNumbersToDisplay = 5;
            DisplayEllipsesWhenNotShowingAllPageNumbers = true;
            EllipsesFormat = "&#8230;";
            LinkToFirstPageFormat = "<<";
            LinkToPreviousPageFormat = "<";
            LinkToNextPageFormat = ">";
            LinkToLastPageFormat = ">>";
            ContainerDivClass = "container";
            UlElementClass = "pagination";
            LiElementClass = "page-item";
            PageClass = "page-link";
            ActiveLiElementClass = "active";
            DisplayPageCountAndCurrentPage = false;
            PageCountAndCurrentPageFormat = "Page {0} of {1}.";
            DisplayEntriesText = false;
            EntriesTextFormat = "Showing {0} to {1} of {2} entries.";
        }

        /// <summary>
        /// In which style that page was show, by default it is set to Simple.
        /// </summary>
        public PagerTypeEnum PagerType { get; set; }

        /// <summary>
        /// How many page numbers to display in pagination, by default it is 5.
        /// </summary>
        public int MaximumPageNumbersToDisplay { get; set; }

        /// <summary>
        /// Adds an ellipe when all pages are not displaying, by default it is true.
        /// </summary>
        public bool DisplayEllipsesWhenNotShowingAllPageNumbers { get; set; }

        /// <summary>
        /// A formatted text shows when all pages are not displaying, by default it is &#8230;
        /// </summary>
        public string EllipsesFormat { get; set; }

        /// <summary>
        /// A formatted text to show for firstpage link, by default it is set to <<.
        /// </summary>
        public string LinkToFirstPageFormat { get; set; }

        /// <summary>
        /// A formatted text to show for previous page link, by default it is set to <.
        /// </summary>
        public string LinkToPreviousPageFormat { get; set; }

        /// <summary>
        /// A formatted text to show for next page link, by default it is set to >.
        /// </summary>
        public string LinkToNextPageFormat { get; set; }

        /// <summary>
        /// A formatted text to show for last page link, by default it is set to >>.
        /// </summary>
        public string LinkToLastPageFormat { get; set; }

        /// <summary>
        /// Css class to append to &lt;div&gt; element in the paging content, by default it is set to container.
        /// </summary>
        public string ContainerDivClass { get; set; }

        /// <summary>
        /// Css class to append to &lt;ul&gt; element in the paging content, by default it is set to pagination.
        /// </summary>
        public string UlElementClass { get; set; }

        /// <summary>
        /// Css class to append to &lt;li&gt; element in the paging content, by default it is set to page-item.
        /// </summary>
        public string LiElementClass { get; set; }

        /// <summary>
        /// Css class to append to &lt;a&gt;/&lt;span&gt; element in the paging content, by default it is set to page-link.
        /// </summary>
        public string PageClass { get; set; }

        /// <summary>
        /// Css class to append to &lt;li&gt; element if active in the paging content, by default it is set to active.
        /// </summary>
        public string ActiveLiElementClass { get; set; }

        /// <summary>
        /// Displaying current page number and total number of pages in pager, by default it is set to false.
        /// </summary>
        /// <example>
        /// Page 10 of 20.
        /// </example>
        public bool DisplayPageCountAndCurrentPage { get; set; }

        /// <summary>
        /// Text format will display if DisplayPageCountAndCurrentPage is true. Use {0} to refer the current page and {0} to refer total number of pages, by default it is set to Page {0} of {1}.
        /// </summary>
        /// <example>
        /// Page 10 of 20.
        /// </example>
        public string PageCountAndCurrentPageFormat { get; set; }

        /// <summary>
        /// Displaying start item, last item and total entries in pager, by default it is set to false.
        /// </summary>
        /// <example>
        /// Showing 1 to 10 of 30 entries.
        /// </example>
        public bool DisplayEntriesText { get; set; }

        /// <summary>
        /// Text format will display if DisplayEntriesText is true. {0} refers first entry on page, {1} refers last item on page and {2} refers total number of entries, by default it is set to Showing {0} to {1} of {2} entries.
        /// </summary>
        /// <example>
        /// Showing 1 to 10 of 30 entries.
        /// </example>
        public string EntriesTextFormat { get; set; }

        /// <summary>
        /// In which style that page was show, by default it is set to Simple.
        /// </summary>
        public enum PagerTypeEnum
        {
            /// <summary>
            /// Simple Page means just shows previous and next page.
            /// </summary>
            Minimal,

            /// <summary>
            /// Minimal page means it shows 12345... pages with next, previous, last page and first page.
            /// </summary>
            Maximal
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P.Pager.Mvc.Core
{
    public class PagerOptions
    {
        public PagerOptions()
        {
            PagerType = PagerTypeEnum.Simple;
            MaximumPageNumbersToDisplay = 10;
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
        }

        /// <summary>
        /// In which style that page was show, by default it is set to Simple.
        /// </summary>
        public PagerTypeEnum PagerType { get; set; }

        /// <summary>
        /// How many page numbers to display in pagination, by default it is 5.
        /// </summary>
        public int MaximumPageNumbersToDisplay { get; }

        /// <summary>
        /// Adds an ellipe when all pages are not displaying, by default it is true.
        /// </summary>
        public bool DisplayEllipsesWhenNotShowingAllPageNumbers { get; }

        /// <summary>
        /// A formatted text shows when all pages are not displaying, by default it is &#8230;
        /// </summary>
        public string EllipsesFormat { get; }

        /// <summary>
        /// A formatted text to show for firstpage link, by default it is set to <<.
        /// </summary>
        public string LinkToFirstPageFormat { get; }

        /// <summary>
        /// A formatted text to show for previous page link, by default it is set to <.
        /// </summary>
        public string LinkToPreviousPageFormat { get; }

        /// <summary>
        /// A formatted text to show for next page link, by default it is set to >.
        /// </summary>
        public string LinkToNextPageFormat { get; }

        /// <summary>
        /// A formatted text to show for last page link, by default it is set to >>.
        /// </summary>
        public string LinkToLastPageFormat { get; }

        /// <summary>
        /// Css class to append to <div> element in the paging content.
        /// </summary>
        public string ContainerDivClass { get; }

        /// <summary>
        /// Css class to append to <ul> element in the paging content.
        /// </summary>
        public string UlElementClass { get; }

        /// <summary>
        /// Css class to append to <li> element in the paging content.
        /// </summary>
        public string LiElementClass { get; }

        /// <summary>
        /// Css class to append to <a>/<span> element in the paging content.
        /// </summary>
        public string PageClass { get; }

        /// <summary>
        /// Css class to append to <li> element if active in the paging content.
        /// </summary>
        public string ActiveLiElementClass { get; }

        /// <summary>
        /// In which style that page was show, by default it is set to Simple.
        /// </summary>
        public enum PagerTypeEnum
        {
            /// <summary>
            /// Simple Page means just shows previous and next page.
            /// </summary>
            Simple,

            /// <summary>
            /// Minimal page means it shows 12345... pages with next, previous, last page and first page.
            /// </summary>
            Minimal
        }
    }
}

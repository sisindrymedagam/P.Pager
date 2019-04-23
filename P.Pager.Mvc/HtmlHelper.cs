using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace P.Pager.Mvc
{
    public static class HtmlHelper
    {
        public static HtmlString Pager(this System.Web.Mvc.HtmlHelper html, IPager pager, Func<int, string> generatePageUrl)
        {
            return Pager(html, pager, generatePageUrl, new PagerOptions());
        }

        public static HtmlString Pager(this System.Web.Mvc.HtmlHelper html, IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            return PageBuilder(html, pager, generatePageUrl, pagerOptions);
        }

        private static HtmlString PageBuilder(System.Web.Mvc.HtmlHelper html, IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var firstPageToDisplay = 1;
            var lastPageToDisplay = pager.TotalPageCount;
            var pageNumbersToDisplay = lastPageToDisplay;

            if (pagerOptions.PagesToDisplay.HasValue && pager.TotalPageCount > pagerOptions.PagesToDisplay)
            {
                var maxPageNumbersToDisplay = pagerOptions.PagesToDisplay.Value;
                firstPageToDisplay = pager.CurrentPageIndex - maxPageNumbersToDisplay / 2;
                if (firstPageToDisplay < 1)
                    firstPageToDisplay = 1;
                pageNumbersToDisplay = maxPageNumbersToDisplay;
                lastPageToDisplay = firstPageToDisplay + pageNumbersToDisplay - 1;
                if (lastPageToDisplay > pager.TotalPageCount)
                    firstPageToDisplay = pager.TotalPageCount - maxPageNumbersToDisplay + 1;
            }

            var listItemLinks = new List<TagBuilder>();

            listItemLinks.Add(First(pager, generatePageUrl, pagerOptions));

            listItemLinks.Add(Previous(pager, generatePageUrl, pagerOptions));

            if (pagerOptions.HasPagerText)
                listItemLinks.Add(PageCountAndCurrentPage(pager, pagerOptions));

            if (pagerOptions.HasEntriesText)
                listItemLinks.Add(DisplayEntriesText(pager, pagerOptions));

            if (pagerOptions.HasIndividualPages)
            {
                if (pagerOptions.HasEllipses && firstPageToDisplay > 1)
                    listItemLinks.Add(Ellipses(pagerOptions));

                foreach (var i in Enumerable.Range(firstPageToDisplay, pageNumbersToDisplay))
                {
                    //show delimiter between page numbers
                    if (i > firstPageToDisplay && !string.IsNullOrWhiteSpace(pagerOptions.TextForDelimiter))
                        listItemLinks.Add(AddToListItem(pagerOptions.TextForDelimiter, pagerOptions.ClassToLi));

                    //show page number link
                    listItemLinks.Add(Page(i, pager, generatePageUrl, pagerOptions));
                }

                if (pagerOptions.HasEllipses && (firstPageToDisplay + pageNumbersToDisplay - 1) < pager.TotalPageCount)
                    listItemLinks.Add(Ellipses(pagerOptions));
            }

            listItemLinks.Add(Next(pager, generatePageUrl, pagerOptions));

            listItemLinks.Add(Last(pager, generatePageUrl, pagerOptions));

            var listItemLinksString = listItemLinks.Aggregate(new StringBuilder(), (sb, listItem) => sb.Append(TagBuilderToString(listItem)), sb => sb.ToString());

            var ul = new TagBuilder("ul");
            AppendHtml(ul, listItemLinksString);
            ul.AddCssClass(pagerOptions.ClassToUl);
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass(pagerOptions.ClassToPagerContainer);
            AppendHtml(outerDiv, TagBuilderToString(ul));
            return new HtmlString(TagBuilderToString(outerDiv));
        }

        private static TagBuilder First(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            const int targetPageNumber = 1;
            var first = new TagBuilder("a");
            AppendHtml(first, string.Format(pagerOptions.TextToFirstPage, targetPageNumber));

            first.AddCssClass(pagerOptions.PageClass);

            if (pager.IsFirstPage)
                return AddToListItem(first, pagerOptions, pagerOptions.ClassToLi + " disabled");

            first.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(first, pagerOptions, pagerOptions.ClassToLi);
        }

        private static TagBuilder Previous(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var targetPageNumber = pager.CurrentPageIndex - 1;
            var previous = new TagBuilder("a");
            AppendHtml(previous, string.Format(pagerOptions.TextToPreviousPage, targetPageNumber));
            previous.Attributes["rel"] = "prev";
            previous.AddCssClass(pagerOptions.PageClass);

            if (!pager.HasPreviousPage)
                return AddToListItem(previous, pagerOptions, pagerOptions.ClassToLi + " disabled");

            previous.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(previous, pagerOptions, pagerOptions.ClassToLi);
        }

        private static TagBuilder Page(int i, IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var format = string.Format(pagerOptions.TextToIndividualPages, i);
            var targetPageNumber = i;
            var page = new TagBuilder("a");
            SetInnerText(page, format);
            page.AddCssClass(pagerOptions.PageClass);
            if (i == pager.CurrentPageIndex)
                return AddToListItem(page, pagerOptions, pagerOptions.ClassToLi + " " + pagerOptions.ClassToActiveLi);

            page.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(page, pagerOptions, null);
        }

        private static TagBuilder Next(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var targetPageNumber = pager.CurrentPageIndex + 1;
            var next = new TagBuilder("a");
            AppendHtml(next, string.Format(pagerOptions.TextToNextPage, targetPageNumber));
            next.Attributes["rel"] = "next";

            next.AddCssClass(pagerOptions.PageClass);

            if (!pager.HasNextPage)
                return AddToListItem(next, pagerOptions, pagerOptions.ClassToLi + " disabled");

            next.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(next, pagerOptions, pagerOptions.ClassToLi);
        }

        private static TagBuilder Last(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var targetPageNumber = pager.TotalPageCount;
            var last = new TagBuilder("a");
            AppendHtml(last, string.Format(pagerOptions.TextToLastPage, targetPageNumber));

            last.AddCssClass(pagerOptions.PageClass);

            if (pager.IsLastPage)
                return AddToListItem(last, pagerOptions, pagerOptions.ClassToLi + " disabled");

            last.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(last, pagerOptions, pagerOptions.ClassToLi);
        }

        private static TagBuilder PageCountAndCurrentPage(IPager pager, PagerOptions pagerOptions)
        {
            var text = new TagBuilder("a");
            text.AddCssClass(pagerOptions.PageClass);
            SetInnerText(text, string.Format(pagerOptions.PagerTextFormat, pager.CurrentPageIndex, pager.TotalPageCount));
            return AddToListItem(text, pagerOptions, pagerOptions.ClassToLi + " disabled");
        }

        private static TagBuilder DisplayEntriesText(IPager pager, PagerOptions pagerOptions)
        {
            var text = new TagBuilder("a");
            text.AddCssClass(pagerOptions.PageClass);
            SetInnerText(text, string.Format(pagerOptions.EntriesTextFormat, pager.StartItemIndex, pager.EndItemIndex, pager.TotalItemCount));
            return AddToListItem(text, pagerOptions, pagerOptions.ClassToLi + " disabled");
        }

        private static TagBuilder Ellipses(PagerOptions pagerOptions)
        {
            var a = new TagBuilder("a");
            a.AddCssClass(pagerOptions.PageClass);
            AppendHtml(a, pagerOptions.EllipsesFormat);
            return AddToListItem(a, pagerOptions, pagerOptions.ClassToLi + " disabled");
        }

        private static void AppendHtml(TagBuilder tagBuilder, string innerHtml)
        {
            tagBuilder.InnerHtml += innerHtml;
        }

        private static void SetInnerText(TagBuilder tagBuilder, string innerText)
        {
            tagBuilder.SetInnerText(innerText);
        }

        private static TagBuilder AddToListItem(string text, string cssClass)
        {
            var li = new TagBuilder("li");
            li.AddCssClass(cssClass);
            SetInnerText(li, text);
            return li;
        }

        private static TagBuilder AddToListItem(TagBuilder inner, PagerOptions pagerOptions, string cssClass)
        {
            var li = new TagBuilder("li");
            li.AddCssClass(cssClass ?? pagerOptions.ClassToLi);
            AppendHtml(li, TagBuilderToString(inner));
            return li;
        }

        private static string TagBuilderToString(TagBuilder tagBuilder, TagRenderMode renderMode = TagRenderMode.SelfClosing)
        {
            return tagBuilder.ToString(renderMode);
        }
    }
}

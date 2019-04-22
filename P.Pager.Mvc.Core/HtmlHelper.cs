using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using static P.Pager.Mvc.Core.PagerOptions;

namespace P.Pager.Mvc.Core
{
    public static class HtmlHelper
    {
        public static HtmlString Pager(this IHtmlHelper html, IPager pager, Func<int, string> generatePageUrl)
        {
            return Pager(html, pager, generatePageUrl, new PagerOptions());
        }

        private static HtmlString Pager(this IHtmlHelper html, IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            if (pagerOptions.PagerType == PagerTypeEnum.Minimal)
            {
                return MinimalPager(html, pager, generatePageUrl, pagerOptions);
            }
            else
            {
                return MaximalPager(html, pager, generatePageUrl, pagerOptions);
            }
        }

        private static HtmlString MinimalPager(IHtmlHelper html, IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var listItemLinks = new List<TagBuilder>();
            listItemLinks.Add(Previous(pager, generatePageUrl, pagerOptions));

            if (pagerOptions.DisplayPageCountAndCurrentPage)
                listItemLinks.Add(PageCountAndCurrentPage(pager, pagerOptions));

            //if (pagerOptions.DisplayEntriesText)
                listItemLinks.Add(DisplayEntriesText(pager, pagerOptions));

            listItemLinks.Add(Next(pager, generatePageUrl, pagerOptions));

            var listItemLinksString = listItemLinks.Aggregate(new StringBuilder(), (sb, listItem) => sb.Append(TagBuilderToString(listItem)), sb => sb.ToString());

            var ul = new TagBuilder("ul");
            AppendHtml(ul, listItemLinksString);
            ul.AddCssClass(pagerOptions.UlElementClass);
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass(pagerOptions.ContainerDivClass);
            AppendHtml(outerDiv, TagBuilderToString(ul));
            return new HtmlString(TagBuilderToString(outerDiv));
        }

        private static HtmlString MaximalPager(IHtmlHelper html, IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            throw new NotImplementedException();
        }

        private static TagBuilder First(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            const int targetPageNumber = 1;
            var first = new TagBuilder("a");
            AppendHtml(first, string.Format(pagerOptions.LinkToFirstPageFormat, targetPageNumber));

            first.AddCssClass(pagerOptions.PageClass);

            if (pager.IsFirstPage)
                return AddToListItem(first, pagerOptions, pagerOptions.LiElementClass + " disabled");

            first.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(first, pagerOptions, pagerOptions.LiElementClass);
        }

        private static TagBuilder Previous(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var targetPageNumber = pager.CurrentPageIndex - 1;
            var previous = new TagBuilder("a");
            AppendHtml(previous, string.Format(pagerOptions.LinkToPreviousPageFormat, targetPageNumber));
            previous.Attributes["rel"] = "prev";
            previous.AddCssClass(pagerOptions.PageClass);

            if (!pager.HasPreviousPage)
                return AddToListItem(previous, pagerOptions, pagerOptions.LiElementClass + " disabled");

            previous.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(previous, pagerOptions, pagerOptions.LiElementClass);
        }

        private static TagBuilder Next(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var targetPageNumber = pager.CurrentPageIndex + 1;
            var next = new TagBuilder("a");
            AppendHtml(next, string.Format(pagerOptions.LinkToNextPageFormat, targetPageNumber));
            next.Attributes["rel"] = "next";

            next.AddCssClass(pagerOptions.PageClass);

            if (!pager.HasNextPage)
                return AddToListItem(next, pagerOptions, pagerOptions.LiElementClass + " disabled");

            next.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(next, pagerOptions, pagerOptions.LiElementClass);
        }

        private static TagBuilder Last(IPager pager, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            var targetPageNumber = pager.TotalPageCount;
            var last = new TagBuilder("a");
            AppendHtml(last, string.Format(pagerOptions.LinkToLastPageFormat, targetPageNumber));

            last.AddCssClass(pagerOptions.PageClass);

            if (pager.IsLastPage)
                return AddToListItem(last, pagerOptions, pagerOptions.LiElementClass + " disabled");

            last.Attributes["href"] = generatePageUrl(targetPageNumber);
            return AddToListItem(last, pagerOptions, pagerOptions.LiElementClass);
        }

        private static TagBuilder PageCountAndCurrentPage(IPager pager, PagerOptions pagerOptions)
        {
            var text = new TagBuilder("a");
            SetInnerText(text, string.Format(pagerOptions.PageCountAndCurrentPageFormat, pager.CurrentPageIndex, pager.TotalPageCount));
            return AddToListItem(text, pagerOptions, pagerOptions.LiElementClass + " disabled");
        }

        private static TagBuilder DisplayEntriesText(IPager pager, PagerOptions pagerOptions)
        {
            var text = new TagBuilder("a");
            SetInnerText(text, string.Format(pagerOptions.EntriesTextFormat, pager.StartItemIndex, pager.EndItemIndex, pager.TotalItemCount));
            return AddToListItem(text, pagerOptions, pagerOptions.LiElementClass + " disabled");
        }


        private static void AppendHtml(TagBuilder tagBuilder, string innerHtml)
        {
            tagBuilder.InnerHtml.AppendHtml(innerHtml);
        }

        private static void SetInnerText(TagBuilder tagBuilder, string innerText)
        {
            tagBuilder.InnerHtml.SetContent(innerText);
        }

        private static TagBuilder AddToListItem(TagBuilder inner, PagerOptions pagerOptions, string cssClass)
        {
            var li = new TagBuilder("li");
            li.AddCssClass(cssClass ?? pagerOptions.LiElementClass);
            AppendHtml(li, TagBuilderToString(inner));
            return li;
        }

        private static string TagBuilderToString(TagBuilder tagBuilder, TagRenderMode renderMode = TagRenderMode.Normal)
        {
            var encoder = HtmlEncoder.Create(new TextEncoderSettings());
            var writer = new System.IO.StringWriter() as TextWriter;
            tagBuilder.WriteTo(writer, encoder);
            return writer.ToString();
        }
    }
}

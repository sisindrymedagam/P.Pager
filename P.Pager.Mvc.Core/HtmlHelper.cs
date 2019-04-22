using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace P.Pager.Mvc.Core
{
    public static class HtmlHelper
    {
        public static HtmlString Pager(this IHtmlHelper html, IPager list, Func<int, string> generatePageUrl)
        {
            return Pager(html, list, generatePageUrl, new PagerOptions());
        }

        private static HtmlString Pager(IHtmlHelper html, IPager list, Func<int, string> generatePageUrl, PagerOptions pagerOptions)
        {
            throw new NotImplementedException();
        }
    }
}

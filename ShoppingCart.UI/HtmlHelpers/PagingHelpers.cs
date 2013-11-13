using System;
using System.Text;
using System.Web.Mvc;
using ShoppingCart.UI.Models;
using System.Web;

namespace ShoppingCart.UI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static string GetLanguageCode(this HtmlHelper html)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["Language"] == null || context.Session["Language"] as string == "tr")
            {
                return "tr";
            }
            else 
            {
                return "en";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Paging.Models;
using System.Web.Mvc;
using System.Text;

namespace Paging.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, 
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                stringBuilder.Append(tag.ToString());
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}
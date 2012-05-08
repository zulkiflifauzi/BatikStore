using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Resources;

namespace WebUI.Component
{
    public static class HtmlComponent
    {
        public static MvcHtmlString DropDownListSingleLine(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> data, int? value)
        {
            var result = new StringBuilder();

            result.Append("<select name=\"" + name + "\" id=\"" + name + "\">");

            result.Append("<option value=\"\">" + GeneralLocalisations.Select + "...</option>");
            foreach (var item in data)
            {
                if (value.HasValue)
                {
                    if (Convert.ToInt32(item.Value) == value.Value)
                        result.Append("<option selected = \"selected\" value=\"" + item.Value + "\">" + item.Text + "</option>");
                    else
                        result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
                }
                else
                    result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
            }
            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString TipTip(this HtmlHelper htmlHelper, string text)
        {
            var result = new StringBuilder();

            result.Append("<text>");

            if (text.Length > 20)
            {
                result.Append(text.Substring(0, 20));
                result.Append("<span style='cursor:pointer' class='tiptip' title='" + text + "'>...</span>");
            }
            else
                result.Append(text);
            result.Append("</text>");    

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controller, object routeValues, string imagePath, string alt)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("title", alt);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

    }
}
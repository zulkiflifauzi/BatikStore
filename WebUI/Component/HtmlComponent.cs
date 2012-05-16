using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Resources;
using WebUI.Models;

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

        public static MvcHtmlString Products(this HtmlHelper html, List<ViewModelProduct> products, string className, string currencySymbol)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<ul>");
            foreach (var item in products)
            {
                string url = item.Pictures.Count > 0 ? item.Pictures.FirstOrDefault().Url : "/Content/images/not-available.gif";
                string description = item.Pictures.Count > 0 ? item.Pictures.FirstOrDefault().Description : "Picture is not available";
                var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
                string targetUrl = urlHelper.Action("Details", "Product", new { id = item.Id });

                result.Append("<li>");
                result.Append("<a class='tiptip ");
                result.Append(className);
                result.Append("' target='_blank' href='");
                result.Append(targetUrl);
                result.Append("' title='");
                result.Append(item.Description + ", " + GeneralLocalisations.Price + " " + currencySymbol + item.Price.ToString());
                result.Append("'><img src='");
                result.Append(url);
                result.Append("' width='200' height='200'/></a>");
                result.Append("</li>");
            }
            result.Append("</ul>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ProductPictures(this HtmlHelper html, List<ViewModelPicture> pictures)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<ul>");
            foreach (var item in pictures)
            {
                result.Append("<li>");
                result.Append("<a rel='lightbox[group]' href='");
                result.Append(item.Url);
                result.Append("' title='");
                result.Append(item.Description);
                result.Append("'><img src='");
                result.Append(item.Url);
                result.Append("' width='200' height='200'/></a>");
                result.Append("</li>");
            }
            result.Append("</ul>");

            return MvcHtmlString.Create(result.ToString());
        }

    }
}
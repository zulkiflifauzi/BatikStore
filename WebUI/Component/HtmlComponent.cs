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
    }
}
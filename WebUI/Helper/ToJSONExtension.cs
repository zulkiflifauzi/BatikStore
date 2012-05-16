using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebUI.Helper
{
    public static class ToJSONExtension
    {
        public static string ToJSON(this object input)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(input);
        }

        public static string ToJSON(this object input, int recursionDepth)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(input);
        }

    }
}
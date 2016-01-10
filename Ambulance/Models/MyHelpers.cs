using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ambulance.Models
{
    public static class MyHelpers
    {
        public static MvcHtmlString MyTextbox(this HtmlHelper html,string name,string id, string text, string className)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type","text");
            tag.MergeAttribute("value",text);
            tag.MergeAttribute("name",name);
            tag.MergeAttribute("id",id);
            tag.MergeAttribute("class",className);
            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}
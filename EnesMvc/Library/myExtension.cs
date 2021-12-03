using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EnesMvc.Library
{
    public static class myExtension
    {
        public static MvcHtmlString  Button(this HtmlHelper helper,String id="",string tip="",string text = "")
        {
            string html = string.Format("<button id='{0}'type='{1}'>{2}</button>", id, tip, text);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Button(this HtmlHelper helper, String id = "",ButtonType tip = ButtonType.Button ,string classCss="",string onclick="", string text = "")
        {
            string html = string.Format($"<button id='{id}'type='{tip}' class='{classCss}' onclick='onclick'>{text}</button>");
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Button(this HtmlHelper helper, String id = "",string cssClass="", ButtonType tip = ButtonType.Button, string text = "")
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass(cssClass);
            tag.GenerateId(id);
            tag.Attributes.Add(new KeyValuePair<string, string>( "type", tip.ToString()));
            tag.Attributes.Add(new KeyValuePair<string, string>( "name", id));
            tag.SetInnerText(text);
            return MvcHtmlString.Create(tag.ToString());
        }
        public enum ButtonType
        {
            Button = 0,
            Submit = 1,
            Reset = 2
        }
    }
}
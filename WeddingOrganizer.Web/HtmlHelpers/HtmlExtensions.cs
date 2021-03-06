﻿using System;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Routing;

namespace WeddingOrganizer.Web.HtmlHelpers
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// ActionLinkUI.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>ActionLink string</returns>
        public static MvcHtmlString ActionLinkUI<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string action)
        {
            return ActionLinkUI(htmlHelper, expression, action, null);
        }

        /// <summary>
        /// ActionLinkUI.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="icon">The icon.</param>
        /// <returns>ActionLink string</returns>
        public static MvcHtmlString ActionLinkUI<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string action, string icon)
        {
            return ActionLinkUI(htmlHelper, expression, action, icon, null);
        }

        /// <summary>
        /// ActionLinkUI.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>ActionLink string</returns>
        public static MvcHtmlString ActionLinkUI<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string action, string icon, object htmlAttributes)
        {
            string controllerName = htmlHelper.ViewContext.RouteData.Values["controller"].ToString();
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            TagBuilder a = new TagBuilder("a");
            switch (action)
            {
                case "Index":
                    a.Attributes.Add("href", String.Format("/{0}", controllerName));
                    a.Attributes.Add("title", "Back to list");
                    break;

                case "Create":
                    a.Attributes.Add("href", String.Format("/{0}/{1}", controllerName, action));
                    a.Attributes.Add("title", "Create new");
                    break;
                default:
                    a.Attributes.Add("href", String.Format("/{0}/{1}/{2}", controllerName, action, metaData.Model));
                    a.Attributes.Add("title", action);
                    break;
            }


            a.AddCssClass("actionLinkUI");
            a.AddCssClass("ui-widget");
            a.AddCssClass("ui-state-default");
            a.AddCssClass("ui-corner-all");

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("ui-icon");
            span.AddCssClass(icon);
            span.InnerHtml = action;
            a.InnerHtml = span.ToString(TagRenderMode.Normal);

            if (htmlAttributes != null)
            {
                a.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            return MvcHtmlString.Create(a.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ActionImage(this HtmlHelper html, string imagePath, string alt, string cssClass,
                                                string action, string controllerName, object routeValues)
        {
            var currentUrl = new UrlHelper(html.ViewContext.RequestContext);
            var imgTagBuilder = new TagBuilder("img"); // build the <img> tag
            imgTagBuilder.MergeAttribute("src", currentUrl.Content(imagePath));
            imgTagBuilder.MergeAttribute("alt", alt);
            imgTagBuilder.MergeAttribute("class", cssClass);
            string imgHtml = imgTagBuilder.ToString(TagRenderMode.SelfClosing);
            var anchorTagBuilder = new TagBuilder("a"); // build the <a> tag
            anchorTagBuilder.MergeAttribute("href", currentUrl.Action(action, controllerName, routeValues));
            anchorTagBuilder.InnerHtml = imgHtml;  // include the <img> tag inside
            string anchorHtml = anchorTagBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(anchorHtml);
        }
    }
}
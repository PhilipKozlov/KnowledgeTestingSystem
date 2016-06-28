using System.Web.Mvc;

namespace MvcPL.Infrastructure.Helpers
{
    /// <summary>
    /// Provides additional functionality for rendering of HTML controls in a view.
    /// </summary>
    public static class CustomHtmlHelpers
    {
        /// <summary>
        /// Returns an HTML button element.
        /// </summary>
        /// <param name="html"> For rendering of HTML controls in a view.</param>
        /// <param name="name"> Button name.</param>
        /// <param name="style"> Button ctyle.</param>
        /// <returns> Generated  button HTML element.</returns>
        public static MvcHtmlString SubmitButton(this HtmlHelper html, string name, string style = null)
        {
            var tag = new TagBuilder("input");
            tag.MergeAttribute("type", "submit", true);
            tag.MergeAttribute("value", name, true);
            if (!string.IsNullOrEmpty(style)) tag.AddCssClass(style);
            return new MvcHtmlString(tag.ToString());
        }
    }
}
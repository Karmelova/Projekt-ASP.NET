using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace YourITMatch.Extensions
{
    public static class NavLinkExtensions
    {
        public static string IsActive(this IHtmlHelper html, string controller = "", string action = "")
        {
            var routeData = html.ViewContext.RouteData;

            string routeAction = (string)routeData.Values["action"];
            if (routeAction == null) routeAction = "";
            string routeController = (string)routeData.Values["controller"];
            if (routeController == null) routeController = "";

            var returnActive = false;
            if (controller == null && action == null)
            {
                returnActive = true;
            }
            else if (controller != null && action == null)
            {
                returnActive = routeController.Equals(controller, StringComparison.OrdinalIgnoreCase);
            }
            else if (controller == null && action != null)
            {
                returnActive = routeAction.Equals(action, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                returnActive = routeAction.Equals(action, StringComparison.OrdinalIgnoreCase) && routeController.Equals(controller, StringComparison.OrdinalIgnoreCase);
            }

            return returnActive ? "active" : "";
        }
    }

    public static class EnumExtensions
    {
        public static List<SelectListItem> ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new SelectListItem
                {
                    Text = e.ToString(),
                    Value = e.ToString(),
                    Selected = e.Equals(enumObj)
                })
                .ToList();
        }

        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, string selectedItem)
    where TEnum : struct, Enum
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };

            return new SelectList(values, "Id", "Name", selectedItem);
        }
    }
}
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
}
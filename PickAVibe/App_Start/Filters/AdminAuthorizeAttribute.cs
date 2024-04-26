using System.Web.Mvc;

namespace PickAVibe.App_Start.Filters
{
    public class AdminAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isAdmin = filterContext.HttpContext.Session["IsAdmin"];
            if (isAdmin == null || !(bool)isAdmin)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
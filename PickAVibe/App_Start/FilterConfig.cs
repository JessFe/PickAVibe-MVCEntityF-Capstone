using System.Web.Mvc;

namespace PickAVibe
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Aggiunge l'attributo Authorize a tutti i controller
            filters.Add(new AuthorizeAttribute());
        }
    }
}

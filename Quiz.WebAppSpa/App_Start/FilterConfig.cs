using System.Web;
using System.Web.Mvc;

namespace Quiz.WebAppSpa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

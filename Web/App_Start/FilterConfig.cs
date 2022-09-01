using System.Web;
using System.Web.Mvc;

namespace Web {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute(), 2); //by default added
            filters.Add(new HandleErrorAttribute {
                View = "Error"
            }, 1);
        }
    }
}

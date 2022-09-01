using System.Web.Mvc;

namespace Web.Areas.ABCCompany {
    public class ABCCompanyAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "ABCCompany";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "ABCCompany_default",
                "ABCCompany/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
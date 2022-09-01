using System.Web.Mvc;

namespace Web.Areas.InformationManagement {
    public class InformationManagementAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "InformationManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "InformationManagement_default",
                "InformationManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using System.Web.Mvc;

namespace Web.Areas.RiskManagement {
    public class RiskManagementAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "RiskManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "RiskManagement_default",
                "RiskManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
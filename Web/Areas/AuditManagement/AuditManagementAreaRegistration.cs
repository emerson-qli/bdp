using System.Web.Mvc;

namespace Web.Areas.AuditManagement {
    public class AuditManagementAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "AuditManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "AuditManagement_default",
                "AuditManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using System.Web.Mvc;

namespace Web.Areas.KnowledgeHub
{
    public class KnowledgeHubAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KnowledgeHub";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KnowledgeHub_default",
                "KnowledgeHub/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
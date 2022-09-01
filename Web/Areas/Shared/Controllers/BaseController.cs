
using Service.ActivityLog;
using Service.Logger;
using Service.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Areas.Shared.Controllers {
    public class BaseController : Controller {

        protected Domain.Models.User CurrentUser() {
            return UserSessionService<Domain.Models.User>.CurrentUser;
        }

        protected JsonResult JsonError(string errorMessage) {
            HttpContext.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;
            return Json(errorMessage);
        }

        protected JsonResult JsonError(string errorMessage, int code) {
            HttpContext.Response.StatusCode = code;
            return Json(errorMessage);
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state) {
            
            var url         = requestContext.HttpContext.Request.Url;
            var currentUser = CurrentUser();
            var pageName    = url.AbsolutePath.Split('/')[1];

            if (currentUser != null) {
                var logActivity = new Domain.Models.ActivityLog {
                    Username    = currentUser.Username,
                    UserId      = currentUser.Id,
                    PageUrl     = url.ToString(),
                    PageName    = pageName
                };

                new ActivityLogService().Save(logActivity);
            }

            

            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void OnException(ExceptionContext filterContext) {

            var _Logger = new LoggerService();

            filterContext.ExceptionHandled = true;

            //Log the error!!
            _Logger.Create(filterContext.Exception);



            //Redirect or return a view, but not both.
            //filterContext.Result = RedirectToAction()
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.ABCCompany.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.ABCCompany.Controllers {
    public class DefaultController : BaseController {

        public ActionResult Index() {
            return View(new DefaultViewModel {
                User = CurrentUser()
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Error.Controllers {
    public class HttpController : Controller {

        public ActionResult code403() {
            return View();
        }

        public ActionResult code404() {
            return View();
        }


        public ActionResult code500() {
            return View();
        }
    }
}
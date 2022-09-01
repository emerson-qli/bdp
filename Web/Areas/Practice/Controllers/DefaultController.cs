using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Practice.Controllers {
    public class DefaultController : BaseController {
        // GET: Practice/Default
        public ActionResult Index() {
            return View();
        }

        public ActionResult Index2() {
            return View();
        }
    }
}
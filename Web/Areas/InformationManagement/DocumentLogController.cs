using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement
{
    public class DocumentLogController : BaseController
    {
        // GET: InformationManagement/DocumentLog
        public ActionResult Index()
        {
            return View();
        }
    }
}
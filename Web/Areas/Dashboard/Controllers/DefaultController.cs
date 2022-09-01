using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Dashboard.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Dashboard.Controllers {
    public class DefaultController : BaseController {
        // GET: Dashboard/Default
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            
            return View(new DashboardViewModel {
                User        = user,
                Employee    = employee
            });
        }
    }
}
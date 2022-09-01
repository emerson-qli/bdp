using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.RiskManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.RiskManagement.Controllers {
    public class ReportsController : BaseController {
        // GET: RiskManagement/Reports
        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new RiskManagementViewModel {
                User = user,
                Employee = employee
            });
        }
    }
}
using Service.Audit;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.AuditManagement.Controllers {
    public class ReportsController : BaseController {

        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                AuditPlans  = new AuditPlanService().GetAllIncluding().ToList(),
                User        = user,
                Employee    = employee
            });
        }
    }
}
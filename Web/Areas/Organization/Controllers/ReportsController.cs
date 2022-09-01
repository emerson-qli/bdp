using Service.Employee;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Organization.Data;
using Web.Areas.Shared.Controllers;
using Service.ActivityLog;

namespace Web.Areas.Organization.Controllers {
    public class ReportsController : BaseController {

        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new OrganizationViewModel {
                User     = user,
                Employee = employee
            });
        }
    }
}
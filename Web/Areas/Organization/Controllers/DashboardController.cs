using Domain.Enums;
using Service.ActivityLog;
using Service.Attributes;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Organization.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Organization.Controllers {
    public class DashboardController : BaseController {


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDashboard)]
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
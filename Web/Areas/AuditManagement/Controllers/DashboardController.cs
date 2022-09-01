using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.AuditManagement.Controllers {
    public class DashboardController : BaseController {


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditManagementDashboard)]
        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                User        = user,
                Employee    = employee
            });
        }
    }
}
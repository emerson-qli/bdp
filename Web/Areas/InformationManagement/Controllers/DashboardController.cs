using Domain.Enums;
using Service.ActivityLog;
using Service.Attributes;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.InformationManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement.Controllers {
    public class DashboardController : BaseController {


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDashboard)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new InformationManagementViewModel {
                User        = user,
                Employee    = employee
            });
        }
    }
}
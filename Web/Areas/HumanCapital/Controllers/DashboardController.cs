using Domain.Enums;
using Service.Attributes;
using Service.Department;
using Service.Employee;
using Service.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.HumanCapital.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.HumanCapital.Controllers {
    public class DashboardController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.HumanCapitalDashboard)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            

            return View(new HumanCapitalViewModel {
                EmployeeCounts      = new EmployeeService().GetAll().Count(),
                PositionCounts      = new PositionService().GetAll().Count(),
                DepartmentCounts    = new DepartmentService().GetAll().Count(),
                User                = user,
                Employee            = employee


            });
        }
    }
}
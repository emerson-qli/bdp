using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Enums;
using System.Web.Mvc;
using Web.Areas.Shared.Controllers;
using Web.Areas.Administration.Data;
using Service.Employee;
using Service.ActivityLog;

namespace Web.Areas.Administration.Controllers
{
    public class UserLogsController : BaseController
    {
        // GET: Administration/UserLogs
        public ActionResult Index()
        {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AdministrationViewModel { 
                ActivityLogs = new ActivityLogService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User     = user,
                Employee = employee
            });
        }
    }
}
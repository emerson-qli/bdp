using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Setting.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Setting.Controllers
{
    public class PrintSettingsController : BaseController
    {
        // GET: Setting/PrintSettings
        public ActionResult Index(){
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                User = CurrentUser(),
                Employee = employee
            });
        }
    }
}
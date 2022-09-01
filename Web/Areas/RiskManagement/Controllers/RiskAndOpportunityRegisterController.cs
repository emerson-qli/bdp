using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.RiskAndOpportunityRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.RiskManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.RiskManagement.Controllers {
    public class RiskAndOpportunityRegisterController : BaseController {

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
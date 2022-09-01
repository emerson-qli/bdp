using Service.Employee;
using Service.Persistence;
using Service.Role;
using Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Account.Models;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Account.Controllers
{
    public class SettingController : BaseController
    {
        // GET: Account/Setting
        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AccountViewModel { 
                User        = CurrentUser(),
                Employee    = employee
            });
        }
        public JsonResult UpdateUser(AccountViewModel viewModel) {
            try {
                var employee = new EmployeeService().GetAllBy(a => a.UserId == viewModel.User.Id).FirstOrDefault();

                var user = new Domain.Models.User {
                    Id = viewModel.User.Id,
                    Username = viewModel.User.Username,
                    Password = viewModel.User.Password,
                    Fullname = employee.Fullname,
                    Tag = Domain.Models.UserStatus.Active,
                    RoleId = viewModel.User.RoleId
                };

                new UserService().Update(user);
                UserSessionService<Domain.Models.User>.End();

                return Json("User Created", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Account.Models;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Account.Controllers
{
    public class ProfileController : BaseController
    {
        public ActionResult Index(Guid? id) {
            var checkId        = "null";
            if (id != null) {
                checkId = "not null";
            }
            var currentUserId   = CurrentUser().Id;
            var userId          = (id.HasValue) ? id.Value : currentUserId;
            var employee        = new EmployeeService().GetAllData(userId);
            var currentEmployee = new EmployeeService().GetAllBy(a => a.UserId == currentUserId).FirstOrDefault();

            return View(new AccountViewModel {
                CheckId         = checkId,
                User            = CurrentUser(),
                CurrentEmployee = currentEmployee,
                Employee        = employee,
                EmployeeReports = new EmployeeReportService().GetAllIncludingRecipients(employee.Id),
            });
        }
        public JsonResult Update(AccountViewModel viewModel) {
            try {
                var data = new EmployeeService().UpdateAndGet(viewModel.Employee);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        public JsonResult UploadPhoto(AccountViewModel viewModel) {
            try {
                var data = new EmployeeService().UploadFile(viewModel.Employee);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        public JsonResult Get(Guid id) {
            try {
                var data = new EmployeeService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
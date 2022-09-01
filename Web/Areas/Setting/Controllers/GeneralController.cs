using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Notification;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Setting.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Setting.Controllers
{
    public class GeneralController : BaseController
    {
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                Settings = new SettingService().GetAll().OrderBy(a => a.Name).ToList(),
                User     = CurrentUser(),
                Employee = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new SettingService().SaveAndGet(viewModel.Setting);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new SettingService().UpdateAndGet(viewModel.Setting);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new SettingService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralView)]
        public JsonResult GetAllIncludingRecipients(Guid id) {
            try {
                var data = new SettingService().GetAllIncludingRecipients(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new SettingService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.GeneralView)]
        public JsonResult TestNotif() {
            try {
                new NotificationService().GetExpiringDocuments();
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
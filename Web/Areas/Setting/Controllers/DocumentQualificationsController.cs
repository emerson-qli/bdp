using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Setting.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Setting.Controllers {
    public class DocumentQualificationsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentQualificationView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new SettingViewModel {
                DocumentQualifications = new DocumentQualificationService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User                   = CurrentUser(),
                Employee               = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentQualificationSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new DocumentQualificationService().SaveAndGet(viewModel.DocumentQualification);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentQualificationSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new DocumentQualificationService().UpdateAndGet(viewModel.DocumentQualification);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentQualificationDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentQualificationService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentQualificationSave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentQualificationService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentQualificationView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentQualificationService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
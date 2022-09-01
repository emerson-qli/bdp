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

namespace Web.Areas.Setting.Controllers
{
    public class DocumentClassificationController : BaseController
    {
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentClassificationView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                DocumentClassifications = new DocumentClassificationService().GetAll().OrderBy(a => a.Name).ToList(),
                User                    = CurrentUser(),
                Employee                = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentClassificationSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new DocumentClassificationService().SaveAndGet(viewModel.DocumentClassification);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentClassificationSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new DocumentClassificationService().UpdateAndGet(viewModel.DocumentClassification);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentClassificationDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentClassificationService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentClassificationSave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentClassificationService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentClassificationView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentClassificationService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
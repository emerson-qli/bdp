using Domain.Enums;
using Service.Attributes;
using Service.Document;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.InformationManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement.Controllers {
    public class DocumentSettingsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentSettingsView)]
        public ActionResult Index() {
            var user            = CurrentUser();
            var employee        = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var documentSetting = new List<Domain.Models.DocumentSetting>();

            if (documentSetting != null) {
                documentSetting = new DocumentSettingService().GetAll().OrderByDescending(a => a.CreatedAt).ToList();
            }

            return View(new InformationManagementViewModel {
                DocumentSettings = documentSetting,
                User             = user,
                Employee         = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentSettingsSave)]
        public JsonResult Save(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentSettingService().SaveAndGet(viewModel.DocumentSetting);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentSettingsSave)]
        public JsonResult Update(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentSettingService().UpdateAndGet(viewModel.DocumentSetting);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentSettingsDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentSettingService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentSettingsView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentSettingService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
using Domain.Enums;
using Service.Attributes;
using Service.Document;
using Service.Employee;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.InformationManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement.Controllers
{
    public class DocumentObsoletionController : BaseController
    {
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentObsoletionView)]
        public ActionResult Index() {
            var user            = CurrentUser();
            var employee        = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var textEditor      = new SettingService().GetAllBy(a => a.Name == "Text Editor").FirstOrDefault();
            return View(new InformationManagementViewModel() { 
                DocumentRequests    = new DocumentRequestService().GetAllBy(a => a.Tag == Domain.Models.DocumentRequestState.Obsolete).ToList(),
                TextEditor          = (textEditor != null) ? textEditor.Value : "Default",
                User                = CurrentUser(),
                Employee            = employee,
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentObsoletionSave)]
        public JsonResult RequestForObsoletion(Guid id) {
            try {
                new DocumentRequestService().RequestForObsoletion(id);
                return Json("Saved", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentObsoletionDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentRequestService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentObsoletionView)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentRequestService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InformationManagementDocumentObsoletionView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentRequestService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
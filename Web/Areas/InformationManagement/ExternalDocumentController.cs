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

namespace Web.Areas.InformationManagement
{
    public class ExternalDocumentController : BaseController
    {
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ExternalDocumentView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var document = new ExternalDocumentService().GetAll().OrderByDescending(a => a.CreatedAt).ToList();
            return View(new InformationManagementViewModel() {
                ExternalDocuments   = document,
                User                = user,
                Employee            = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ExternalDocumentSave)]
        public JsonResult Save(InformationManagementViewModel viewModel) {
            try {
                var data = new ExternalDocumentService().SaveAndGet(viewModel.ExternalDocument);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ExternalDocumentSave)]
        public JsonResult Update(InformationManagementViewModel viewModel) {
            try {
                var data = new ExternalDocumentService().UpdateAndGet(viewModel.ExternalDocument);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ExternalDocumentDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new ExternalDocumentService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ExternalDocumentView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new ExternalDocumentService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ExternalDocumentView)]
        public JsonResult GetAll(Guid id) {
            try {
                var data = new ExternalDocumentService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
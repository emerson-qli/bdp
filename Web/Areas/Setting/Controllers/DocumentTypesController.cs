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
    public class DocumentTypesController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new SettingViewModel {
                DocumentGroups = new DocumentGroupService().GetAllBy(a => a.Tag == Domain.Models.DocumentGroupState.Active).ToList(),
                Employee       = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeView)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new DocumentGroupService().SaveAndGet(viewModel.DocumentGroup);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new DocumentGroupService().UpdateAndGet(viewModel.DocumentGroup);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentGroupService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeSave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentGroupService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeSave)]
        public JsonResult GetAllBy(Guid id) {
            try {
                var data = new DocumentGroupService().GetAllBy(a => a.DocumentCategoryId == id).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SettingDocumentTypeView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentGroupService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
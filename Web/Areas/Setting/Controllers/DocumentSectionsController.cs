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
    public class DocumentSectionsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentSectionView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new SettingViewModel {
                DocumentSections    = new DocumentSectionService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                Employee            = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentSectionSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new DocumentSectionService().SaveAndGet(viewModel.DocumentSection);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentSectionSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new DocumentSectionService().UpdateAndGet(viewModel.DocumentSection);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentSectionDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentSectionService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentSectionSave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentSectionService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentSectionView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentSectionService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
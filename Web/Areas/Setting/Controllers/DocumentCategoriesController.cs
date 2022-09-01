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
    public class DocumentCategoriesController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentCategoryView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                DocumentCategories  = new DocumentCategoryService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                Employee            = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentCategorySave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new DocumentCategoryService().SaveAndGet(viewModel.DocumentCategory);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentCategorySave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new DocumentCategoryService().UpdateAndGet(viewModel.DocumentCategory);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentCategoryDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentCategoryService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentCategorySave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentCategoryService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentCategoryView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentCategoryService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
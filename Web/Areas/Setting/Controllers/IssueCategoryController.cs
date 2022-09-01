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
    public class IssueCategoryController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueCategoryView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new SettingViewModel {
                IssueCategories = new IssueCategoryService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueCategorySave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new IssueCategoryService().SaveAndGet(viewModel.IssueCategory);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueCategorySave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new IssueCategoryService().UpdateAndGet(viewModel.IssueCategory);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueCategoryDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new IssueCategoryService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueCategorySave)]
        public JsonResult GetAll() {
            try {
                var data = new IssueCategoryService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueCategoryView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new IssueCategoryService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
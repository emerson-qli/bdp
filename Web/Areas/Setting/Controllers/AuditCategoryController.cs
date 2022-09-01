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
    public class AuditCategoryController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategoryView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel { 
                AuditCategories = new AuditCategoryService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategorySave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new AuditCategoryService().SaveAndGet(viewModel.AuditCategory); 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategorySave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new AuditCategoryService().UpdateAndGet(viewModel.AuditCategory); 
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategoryDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new AuditCategoryService().Delete(id); 
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategorySave)]
        public JsonResult GetAll() {
            try {
                var data = new AuditCategoryService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategoryView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new AuditCategoryService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
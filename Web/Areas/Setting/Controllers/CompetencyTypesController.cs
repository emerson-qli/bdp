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
    public class CompetencyTypesController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CompetencyTypeView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault(); 
            return View(new SettingViewModel {
                CompetencyTypes = new ComptencyTypeService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CompetencyTypeSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new ComptencyTypeService().SaveAndGet(viewModel.CompetencyType); 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CompetencyTypeSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new ComptencyTypeService().UpdateAndGet(viewModel.CompetencyType); 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CompetencyTypeSave)]
        public JsonResult Delete(Guid id) {
            try {
                new ComptencyTypeService().Delete(id); 
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CompetencyTypeSave)]
        public JsonResult GetAll() {
            try {
                var data = new ComptencyTypeService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CompetencyTypeSave)]
        public JsonResult Get(Guid id) {
            try {
                var data = new ComptencyTypeService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
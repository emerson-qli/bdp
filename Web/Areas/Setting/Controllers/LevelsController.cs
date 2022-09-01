using Domain.Enums; 
using Service.Attributes;
using Service.Employee;
using Service.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.HumanCapital.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Setting.Controllers {
    public class LevelsController : BaseController {


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new HumanCapitalViewModel {
                Levels   = new LevelService().GetAll().OrderBy(a => a.Order).ToList(),
                User     = CurrentUser(),
                Employee = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentSave)]
        public JsonResult Save(HumanCapitalViewModel viewModel) {
            try {
                var data = new LevelService().SaveAndGet(viewModel.Level);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentSave)]
        public JsonResult Update(HumanCapitalViewModel viewModel) {
            try {
                var data = new LevelService().UpdateAndGet(viewModel.Level);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new LevelService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentSave)]
        public JsonResult GetAll() {
            try {
                var data = new LevelService().GetAll().OrderBy(a => a.Order).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new LevelService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentView)]
        public JsonResult GetCurrentAndBelowLevel(Guid id) {
            try {
                var data = new LevelService().GetCurrentAndBelowLevel(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
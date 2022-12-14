using Domain.Enums;
using Service.Attributes;
using Service.Department;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.HumanCapital.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.HumanCapital.Controllers
{
    public class DepartmentsController : BaseController{


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentView)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            

            return View(new HumanCapitalViewModel {
                Departments = new DepartmentService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User        = CurrentUser(),
                Employee    = employee

            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentSave)]
        public JsonResult Save(HumanCapitalViewModel viewModel) {
            try {
                var data = new DepartmentService().SaveAndGet(viewModel.Department);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentSave)]
        public JsonResult Update(HumanCapitalViewModel viewModel) {
            try {
                var data = new DepartmentService().UpdateAndGet(viewModel.Department);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DepartmentService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentSave)]
        public JsonResult GetAll() {
            try {
                var data = new DepartmentService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DepartmentView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DepartmentService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
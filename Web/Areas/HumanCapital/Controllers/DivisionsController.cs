using Domain.Enums;
using Service.Attributes;
using Service.Division;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.HumanCapital.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.HumanCapital.Controllers {
    public class DivisionsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DivisionView)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new HumanCapitalViewModel {
                Divisions   = new DivisionService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User        = CurrentUser(),
                Employee    = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DivisionSave)]
        public JsonResult Save(HumanCapitalViewModel viewModel) {
            try {
                var data = new DivisionService().SaveAndGet(viewModel.Division);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DivisionSave)]
        public JsonResult Update(HumanCapitalViewModel viewModel) {
            try {
                var data = new DivisionService().UpdateAndGet(viewModel.Division);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DivisionDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DivisionService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DivisionSave)]
        public JsonResult GetAll() {
            try {
                var data = new DivisionService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DivisionView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DivisionService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
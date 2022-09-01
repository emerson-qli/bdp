using Domain.Enums;
using Service.Attributes;
using Service.ActionPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;
using Service.Employee;

namespace Web.Areas.AuditManagement.Controllers {
    public class ActionPlanController : BaseController {

        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                ActionPlans = new ActionPlanService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User        = CurrentUser(),
                Employee    = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ActionPlanSave)]
        public JsonResult Save(AuditManagementViewModel viewModel) {
            try {
                var data = new ActionPlanService().SaveAndGet(viewModel.ActionPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ActionPlanSave)]
        public JsonResult Update(AuditManagementViewModel viewModel) {
            try {
                var data = new ActionPlanService().UpdateAndGet(viewModel.ActionPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ActionPlanDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new ActionPlanService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ActionPlanSave)]
        public JsonResult GetAll() {
            try {
                var data = new ActionPlanService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ActionPlanView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new ActionPlanService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
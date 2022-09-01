using Domain.Enums;
using Service.Attributes;
using Service.AnnualPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;
using Service.Employee;
using Service.Audit;
using Service.Setting;

namespace Web.Areas.AuditManagement.Controllers {
    public class AnnualPlansController : BaseController {

        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                AuditPlans         = new AuditPlanService().GetAllAudits().OrderByDescending(a => a.CreatedAt).ToList(),
                AuditAuditors       = new AuditAuditorService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                Employee            = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AnnualPlanSave)]
        public JsonResult Save(AuditManagementViewModel viewModel) {
            try {
                var data = new AnnualPlanService().SaveAndGet(viewModel.AnnualPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AnnualPlanSave)]
        public JsonResult Update(AuditManagementViewModel viewModel) {
            try {
                var data = new AnnualPlanService().UpdateAndGet(viewModel.AnnualPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AnnualPlanDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new AnnualPlanService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AnnualPlanSave)]
        public JsonResult GetAll() {
            try {
                var data = new AnnualPlanService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AnnualPlanView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new AnnualPlanService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.AuditManagement.Controllers {
    public class IssueTrackerController : BaseController {

        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                IssueTrackers   = new IssueTrackerService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTrackerSave)]
        public JsonResult Save(AuditManagementViewModel viewModel) {
            try {
                var data = new IssueTrackerService().SaveAndGet(viewModel.IssueTracker);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTrackerSave)]
        public JsonResult Update(AuditManagementViewModel viewModel) {
            try {
                var data = new IssueTrackerService().UpdateAndGet(viewModel.IssueTracker);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTrackerDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new IssueTrackerService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTrackerSave)]
        public JsonResult GetAll() {
            try {
                var data = new IssueTrackerService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTrackerView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new IssueTrackerService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
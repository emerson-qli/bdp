using Domain.Enums;
using Service.Attributes;
using Service.AuditCalendar;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.AuditManagement.Controllers {
    public class AuditCalendarController : BaseController {

        public ActionResult Index() {
            var user            = CurrentUser();
            var employee        = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                AuditCalendars  = new AuditCalendarService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCalendarSave)]
        public JsonResult Save(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditCalendarService().SaveAndGet(viewModel.AuditCalendar);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCalendarSave)]
        public JsonResult Update(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditCalendarService().UpdateAndGet(viewModel.AuditCalendar);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCalendarDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new AuditCalendarService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCalendarSave)]
        public JsonResult GetAll() {
            try {
                var data = new AuditCalendarService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCalendarView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new AuditCalendarService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
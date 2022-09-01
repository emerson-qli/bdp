using Domain.Enums;
using Service.Attributes;
using Service.AuditTeam;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.AuditManagement.Controllers {
    public class AuditTeamsController : BaseController {

        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                AuditTeams  = new AuditTeamService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User        = CurrentUser(),
                Employee    = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditTeamSave)]
        public JsonResult Save(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditTeamService().SaveAndGet(viewModel.AuditTeam);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditTeamSave)]
        public JsonResult Update(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditTeamService().UpdateAndGet(viewModel.AuditTeam);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditTeamDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new AuditTeamService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditTeamSave)]
        public JsonResult GetAll() {
            try {
                var data = new AuditTeamService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditTeamView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new AuditTeamService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
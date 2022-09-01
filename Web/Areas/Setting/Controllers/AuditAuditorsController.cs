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
    public class AuditAuditorsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditAuditorView)]
        public ActionResult Index() {
            var user            = CurrentUser();
            var employee        = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                AuditAuditors   = new AuditAuditorService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditAuditorSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new AuditAuditorService().SaveAndGet(viewModel.AuditAuditor);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditAuditorSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new AuditAuditorService().UpdateAndGet(viewModel.AuditAuditor);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditAuditorDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new AuditAuditorService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditAuditorSave)]
        public JsonResult GetAll() {
            try {
                var data = new AuditAuditorService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditAuditorView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new AuditAuditorService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
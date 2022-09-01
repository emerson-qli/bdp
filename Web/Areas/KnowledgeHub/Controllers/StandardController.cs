using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.KnowledgeHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.KnowledgeHub.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.KnowledgeHub.Controllers
{
    public class StandardController : BaseController {

        public ActionResult Index(){
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new KnowledgeHubViewModel {
                KnowledgeHubStandards   = new KnowledgeHubStandardService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User                    = CurrentUser(),
                Employee                = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategorySave)]
        public JsonResult Save(KnowledgeHubViewModel viewModel) {
            try {
                var data = new KnowledgeHubStandardService().SaveAndGet(viewModel.KnowledgeHubStandard);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategorySave)]
        public JsonResult Update(KnowledgeHubViewModel viewModel) {
            try {
                var data = new KnowledgeHubStandardService().UpdateAndGet(viewModel.KnowledgeHubStandard);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategoryDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new KnowledgeHubStandardService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategorySave)]
        public JsonResult GetAll() {
            try {
                var data = new KnowledgeHubStandardService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.AuditCategoryView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new KnowledgeHubStandardService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
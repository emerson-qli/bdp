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
    public class IssueTypesController : BaseController {
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTypeView)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new SettingViewModel {
                IssueTypes  = new IssueTypeService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User        = CurrentUser(),
                Employee    = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTypeSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new IssueTypeService().SaveAndGet(viewModel.IssueType);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTypeSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new IssueTypeService().UpdateAndGet(viewModel.IssueType);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTypeDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new IssueTypeService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTypeView)]
        public JsonResult GetAll() {
            try {
                var data = new IssueTypeService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.IssueTypeView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new IssueTypeService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
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
    public class BusinessRiskTypesController : BaseController {
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.BusinessRiskTypeView)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new SettingViewModel {
                BusinessRiskTypes = new BusinessRiskTypeService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User              = CurrentUser(),
                Employee          = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.BusinessRiskTypeSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new BusinessRiskTypeService().SaveAndGet(viewModel.BusinessRiskType);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.BusinessRiskTypeSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new BusinessRiskTypeService().UpdateAndGet(viewModel.BusinessRiskType);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.BusinessRiskTypeDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new BusinessRiskTypeService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.BusinessRiskTypeView)]
        public JsonResult GetAll() {
            try {
                var data = new BusinessRiskTypeService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.BusinessRiskTypeView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new BusinessRiskTypeService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
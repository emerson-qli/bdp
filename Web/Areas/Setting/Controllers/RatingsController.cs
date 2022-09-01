using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Setting.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Setting.Controllers {
    public class RatingsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.RatingView)]
        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault(); 

            return View(new SettingViewModel {
                Ratings  = new RatingService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User     = CurrentUser(),
                Employee = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.RatingSave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new RatingService().SaveAndGet(viewModel.Rating);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.RatingSave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new RatingService().UpdateAndGet(viewModel.Rating);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.RatingDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new RatingService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.RatingSave)]
        public JsonResult GetAll() {
            try {
                var data = new RatingService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.RatingView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new RatingService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
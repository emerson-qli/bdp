using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.HumanCapital.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.HumanCapital.Controllers
{
    public class PositionsController : BaseController {


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PositionView)]
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new HumanCapitalViewModel {
                Positions   = new PositionService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User        = CurrentUser(),
                Employee    = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PositionSave)]
        public JsonResult Save(HumanCapitalViewModel viewModel) {
            try {
                var data        = new PositionService().SaveAndGet(viewModel.Position);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PositionSave)]
        public JsonResult Update(HumanCapitalViewModel viewModel) {
            try {
                var data = new PositionService().UpdateAndGet(viewModel.Position);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PositionDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new PositionService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PositionSave)]
        public JsonResult GetAll() {
            try {
                var data = new PositionService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PositionView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new PositionService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }
}
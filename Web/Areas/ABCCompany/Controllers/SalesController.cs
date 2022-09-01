using Domain.Enums;
using Service.ABCCompany;
using Service.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.ABCCompany.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.ABCCompany.Controllers {
    public class SalesController : BaseController {

        public ActionResult Index() {
            return View();
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SaleSave)]
        public JsonResult Save(SaleViewModel viewModel) {
            try {
                var data = new SaleService().SaveAndGet(viewModel.Sale);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SaleView)]
        public JsonResult GetAllByFilter(SaleViewModel viewModel) {
            try {
                var data = new SaleService().GetAllByFilter(viewModel.Filter);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.SaleSave)]
        public JsonResult Get(Guid id) {
            try {
                var data = new SaleService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


    }
}
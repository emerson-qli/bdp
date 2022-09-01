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
    public class CustomersController : BaseController {

        public ActionResult Index() {
            return View();
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CustomerView)]
        public JsonResult GetCustomer(Guid id) {
            try {
                var data = new CustomerService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CustomerSave)]
        public JsonResult SaveCustomer(CustomerViewModel viewModel) {
            try {
                var data = new CustomerService().SaveAndGet(viewModel.Customer);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.CustomerView)]
        public JsonResult GetAllCustomer() {
            try {
                var data = new CustomerService().GetAll();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }



    }
}
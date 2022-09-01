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
    public class LocationsController : BaseController {

        public ActionResult Country() {

            return View(new LocationViewModel {
                User      = CurrentUser(),
                Countries = new CountryService().GetAll().OrderBy(a => a.Name).ToList()
            });
        }
        public ActionResult RegionState(Guid? id) {

            var country         = (id.HasValue) ? new CountryService().Get(id.Value) : new Domain.Models.Country();
            var stateRegions    = (id.HasValue) ? new CountryStateRegionService().GetAllBy(a => a.CountryId == id.Value).OrderBy(a => a.Name).ToList() : new CountryStateRegionService().GetAll().ToList();

            return View(new LocationViewModel {
                User                = CurrentUser(),
                Country             = country,
                CountryStateRegions = stateRegions
            });
        }
        public ActionResult City(Guid? id) {

            var stateRegion = (id.HasValue) ? new CountryStateRegionService().Get(id.Value) : new Domain.Models.CountryStateRegion();
            var cities      = (id.HasValue) ? new CityService().GetAllBy(a => a.CountryStateRegionId == id).OrderBy(a => a.Name).ToList() : new List<Domain.Models.City>();

            return View(new LocationViewModel {
                User                = CurrentUser(),
                CountryStateRegion  = stateRegion,
                Cities              = cities
            });
        }

        #region Get

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationView)]
        public JsonResult GetCountry(Guid id) {
            try {
                var data = new CountryService().GetIncludingChild(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationView)]
        public JsonResult GetStateRegion(Guid id) {
            try {
                var data = new CountryStateRegionService().GetIncludingChild(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationView)]
        public JsonResult GetCity(Guid id) {
            try {
                var data = new CityService().GetIncludingChild(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #endregion

        #region Save


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationSave)]
        public JsonResult SaveCountry(LocationViewModel viewModel) {
            try {
                var data = new CountryService().SaveAndGet(viewModel.Country);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationSave)]
        public JsonResult SaveStateRegion(LocationViewModel viewModel) {
            try {
                var data = new CountryStateRegionService().SaveAndGet(viewModel.CountryStateRegion);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationSave)]
        public JsonResult SaveCity(LocationViewModel viewModel) {
            try {
                var data = new CityService().SaveAndGet(viewModel.City);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion


        #region Update


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationSave)]
        public JsonResult UpdateCountry(LocationViewModel viewModel) {
            try {
                var data = new CountryService().UpdateAndGet(viewModel.Country);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationSave)]
        public JsonResult UpdateStateRegion(LocationViewModel viewModel) {
            try {
                var data = new CountryStateRegionService().UpdateAndGet(viewModel.CountryStateRegion);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationSave)]
        public JsonResult UpdateCity(LocationViewModel viewModel) {
            try {
                var data = new CityService().UpdateAndGet(viewModel.City);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Delete
        public JsonResult DeleteCountry(Guid id) {
            try {
                new CountryService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        public JsonResult DeleteCity(Guid id) {
            try {
                new CityService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        public JsonResult DeleteRegionState(Guid id) {
            try {
                new CountryStateRegionService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region List

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationView)]
        public JsonResult GetAllCountries() {
            try {
                var data = new CountryService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }catch(Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationView)]
        public JsonResult GetAllStateRegions() {
            try {
                var data = new CountryStateRegionService().GetAll();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.LocationView)]
        public JsonResult GetAllCities() {
            try {
                var data = new CityService().GetAll();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

    }
}
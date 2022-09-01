using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Organization;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Organization.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Organization.Controllers {
    public class ContextController : BaseController {

        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var organization = new OrganizationService().GetAllBy(a => a.Tag == Domain.Models.OrganizationState.Active).FirstOrDefault();

            if (organization == null) {

                var organizationBlank = new Domain.Models.Organization();

                return View(new OrganizationViewModel {
                    Organization    = organizationBlank,
                    Strengths       = new List<Domain.Models.OrganizationContextSWOT>(),
                    Weaknesses      = new List<Domain.Models.OrganizationContextSWOT>(),
                    Opportunities   = new List<Domain.Models.OrganizationContextSWOT>(),
                    Threats         = new List<Domain.Models.OrganizationContextSWOT>(),
                    Politicals      = new List<Domain.Models.OrganizationContextPESTLE>(),
                    Economicals     = new List<Domain.Models.OrganizationContextPESTLE>(),
                    Socials         = new List<Domain.Models.OrganizationContextPESTLE>(),
                    Technologicals  = new List<Domain.Models.OrganizationContextPESTLE>(),
                    Legals          = new List<Domain.Models.OrganizationContextPESTLE>(),
                    Ecologicals     = new List<Domain.Models.OrganizationContextPESTLE>(),
                    Generals        = new List<Domain.Models.OrganizationContextPESTLE>(),
                    IssueCategories = new IssueCategoryService().GetAllBy(a => a.Tag == Domain.Models.IssueCategoryState.Active).ToList(),
                    InternalIssues  = new List<Domain.Models.OrganizationContextInternalIssue>(),
                    ExternalIssues  = new List<Domain.Models.OrganizationContextExternalIssue>(),
                    User            = CurrentUser(),
                    Employee        = employee
                });
            }
            else {

                return View(new OrganizationViewModel {
                    Organization    = organization,
                    Strengths       = new OrganizationContextSWOTService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextSWOTState.Strength).ToList(),
                    Weaknesses      = new OrganizationContextSWOTService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextSWOTState.Weakness).ToList(),
                    Opportunities   = new OrganizationContextSWOTService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextSWOTState.Opportunities).ToList(),
                    Threats         = new OrganizationContextSWOTService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextSWOTState.Threats).ToList(),
                    Politicals      = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.Political).ToList(),
                    Economicals     = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.Economical).ToList(),
                    Socials         = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.Social).ToList(),
                    Technologicals  = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.Technological).ToList(),
                    Legals          = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.Legal).ToList(),
                    Ecologicals     = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.Ecological).ToList(),
                    Generals        = new OrganizationContextPESTLEService().GetAllBy(a => a.OrganizationId == organization.Id && a.Tag == Domain.Models.OrganizationContextPESTLEState.General).ToList(),
                    IssueCategories = new IssueCategoryService().GetAllBy(a => a.Tag == Domain.Models.IssueCategoryState.Active).ToList(),
                    InternalIssues  = new OrganizationContextInternalIssueService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    ExternalIssues  = new OrganizationContextExternalIssueService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    User            = CurrentUser(),
                    Employee        = employee
                });
            }
        }

        #region SWOT
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveSWOT(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextSWOTService().SaveAndGet(viewModel.SWOT);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateSWOT(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextSWOTService().UpdateAndGet(viewModel.SWOT);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteSWOT(Guid id) {
            try {
                new OrganizationContextSWOTService().Delete(id);
                return Json("DELETED", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetSWOT(Guid id) {
            try {
                var data = new OrganizationContextSWOTService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region PESTLE
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SavePESTLE(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextPESTLEService().SaveAndGet(viewModel.PESTLE);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdatePESTLE(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextPESTLEService().UpdateAndGet(viewModel.PESTLE);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeletePESTLE(Guid id) {
            try {
                new OrganizationContextPESTLEService().Delete(id);
                return Json("DELETED", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetPESTLE(Guid id) {
            try {
                var data = new OrganizationContextPESTLEService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Internal Issues
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveInternalIssue(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextInternalIssueService().SaveAndGet(viewModel.InternalIssue);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateInternalIssue(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextInternalIssueService().UpdateAndGet(viewModel.InternalIssue);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteInternalIssue(Guid id) {
            try {
                new OrganizationContextInternalIssueService().Delete(id);
                return Json("DELETED", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetInternalIssue(Guid id) {
            try {
                var data = new OrganizationContextInternalIssueService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Internal Issues
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveExternalIssue(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextExternalIssueService().SaveAndGet(viewModel.ExternalIssue);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateExternalIssue(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationContextExternalIssueService().UpdateAndGet(viewModel.ExternalIssue);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteExternalIssue(Guid id) {
            try {
                new OrganizationContextExternalIssueService().Delete(id);
                return Json("DELETED", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetExternalIssue(Guid id) {
            try {
                var data = new OrganizationContextExternalIssueService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion
    }
}
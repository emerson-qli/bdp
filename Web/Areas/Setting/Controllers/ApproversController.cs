using Domain.Enums;
using Service.Attributes;
using Service.ApprovingAuthority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Setting.Data;
using Web.Areas.Shared.Controllers;
using Service.Employee; 

namespace Web.Areas.Setting.Controllers {
    public class ApproversController : BaseController {

        #region Approvers
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthorityView)]
        public ActionResult Index() {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                ApprovingAuthorities = new ApprovingAuthorityService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                User                 = CurrentUser(),
                Employee             = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult Save(SettingViewModel viewModel) {
            try {
                var data = new ApprovingAuthorityService().SaveAndGet(viewModel.ApprovingAuthority);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult Update(SettingViewModel viewModel) {
            try {
                var data = new ApprovingAuthorityService().UpdateAndGet(viewModel.ApprovingAuthority);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthorityDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new ApprovingAuthorityService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult GetAllApprovers() {
            try {
                var data = new ApprovingAuthorityService().GetAll().Where(a => a.Tag == Domain.Models.ApprovingAuthorityState.Approver).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult GetAllReviewers() {
            try {
                var data = new ApprovingAuthorityService().GetAll().Where(a => a.Tag == Domain.Models.ApprovingAuthorityState.Reviewer).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult GetAllPublishers() {
            try {
                var data = new ApprovingAuthorityService().GetAll().Where(a => a.Tag == Domain.Models.ApprovingAuthorityState.Publisher).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthorityView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new ApprovingAuthorityService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #endregion

        #region Members
        public ActionResult Members(Guid id) {
            var user     = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SettingViewModel {
                ApprovingAuthority        = new ApprovingAuthorityService().Get(id),
                ApprovingAuthorityMembers = new ApprovingAuthorityMemberService().GetAll().Where(a => a.ApprovingAuthorityId == id).ToList().OrderByDescending(a => a.CreatedAt).ToList(),
                User                      = CurrentUser(),
                Employee                  = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult SaveMember(SettingViewModel viewModel) {
            try {
                var data = new ApprovingAuthorityMemberService().SaveAndGet(viewModel.ApprovingAuthorityMember);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult UpdateMember(SettingViewModel viewModel) {
            try {
                var data = new ApprovingAuthorityMemberService().UpdateAndGet(viewModel.ApprovingAuthorityMember);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthorityDelete)]
        public JsonResult DeleteMember(Guid id) {
            try {
                new ApprovingAuthorityMemberService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthoritySave)]
        public JsonResult GetAllMembers() {
            try {
                var data = new ApprovingAuthorityMemberService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.ApprovingAuthorityView)]
        public JsonResult GetMember(Guid id) {
            try {
                var data = new ApprovingAuthorityMemberService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #endregion

    }
}
using Domain.Enums;
using Service.ApprovingAuthority;
using Service.Attributes;
using Service.Document;
using Service.Employee;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.InformationManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement.Controllers {
    public class ChangeRequestsController : BaseController {
        // GET: InformationManagement/ChangeRequests
        public ActionResult Index() {
            var user        = CurrentUser();
            var employee    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var position    = new EmployeePositionService().GetAllBy(a => a.EmployeeId == employee.Id && a.Tag == Domain.Models.EmployeePositionState.Active).FirstOrDefault();
            var textEditor  = new SettingService().GetAllBy(a => a.Name == "Text Editor").FirstOrDefault();

            return View(new InformationManagementViewModel {
                DocumentRequests    = new DocumentRequestService().GetAllBy(a => a.Tag == Domain.Models.DocumentRequestState.Revised).ToList(),
                TextEditor          = (textEditor != null) ? textEditor.Value : "Default",
                User                = CurrentUser(),
                Employee            = employee,
                Position            = (position == null) ? new Domain.Models.EmployeePosition {
                    DepartmentName = "Blank"
                } : position
            });
        }

        public ActionResult View(Guid id) {
            var documentRequest = new DocumentRequestService().Get(id);
            var user            = CurrentUser();

            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new InformationManagementViewModel {
                DocumentRequest         = documentRequest,
                DocumentRequestComments = new DocumentRequestCommentService().GetAllBy(a => a.DocumentRequestId == documentRequest.Id).ToList(),
                Approvers               = new ApprovingAuthorityMemberService().GetMembers(documentRequest.ApproverSetId),
                Reviewers               = new ApprovingAuthorityMemberService().GetMembers(documentRequest.ReviewerSetId),
                Publishers              = new ApprovingAuthorityMemberService().GetMembers(documentRequest.PublisherSetId),
                User                    = user,
                Employee                = employee
            });
        }
        public ActionResult ViewHtml(Guid id) {

            var documentRequest = new DocumentRequestService().Get(id);

            return View(new InformationManagementViewModel {
                Content = documentRequest.Content
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentsForChangeRequestsSave)]
        public JsonResult Save(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentsForChangeRequestsService().SaveAndGet(viewModel.DocumentsForChangeRequests);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

       

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult DuplicateDocumentRequest(Guid id) {
            try {
                new DocumentRequestService().DuplicateDocumentRequest(id);
                return Json("Saved", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentsForChangeRequestsDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentsForChangeRequestsService().Delete(id); 
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
       

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentsForChangeRequestsSave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentRequestService().GetAllBy(a => a.Tag == Domain.Models.DocumentRequestState.Publish || a.Tag == Domain.Models.DocumentRequestState.Revised).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentsForChangeRequestsView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentsForChangeRequestsService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
using Domain.Enums;
using Service.ApprovingAuthority;
using Service.Attributes;
using Service.Document;
using Service.Employee;
using Service.Organization;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.InformationManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement.Controllers {
    public class DocumentRequestsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestView)]
        public ActionResult Index() {

            var user            = CurrentUser();
            var employee        = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var documentRequest = new DocumentRequestService().GetAll().OrderByDescending(a => a.CreatedAt).ToList();
            var position        = new EmployeePositionService().GetAllBy(a => a.EmployeeId == employee.Id && a.Tag == Domain.Models.EmployeePositionState.Active).FirstOrDefault();
            var organization    = new OrganizationService().GetAllBy(a => a.Tag == Domain.Models.OrganizationState.Active).FirstOrDefault();
            organization        = (organization == null) ? new Domain.Models.Organization() : organization;

            return View(new InformationManagementViewModel {
                DocumentRequests = documentRequest,
                Organization     = organization,
                User             = user,
                Employee         = employee,
                Position         = (position == null) ? new Domain.Models.EmployeePosition {
                                         DepartmentName = "Blank"
                                    } : position
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestView)]
        public ActionResult View(Guid id) {
            var documentRequest                     = new DocumentRequestService().Get(id);
            var user                                = CurrentUser();
            var employee                            = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var textEditor                          = new SettingService().GetAllBy(a => a.Name == "Text Editor").FirstOrDefault();

            var documentRequestSupportingDocuments  = new List<Domain.Models.DocumentRequestSupportingDocument>();

            var documentRequestExternalDocuments = new List<Domain.Models.DocumentRequestExternalDocument>();

            var approvers                           = new List<Domain.Models.ApprovingAuthorityMember>();
            var reviewers                           = new List<Domain.Models.ApprovingAuthorityMember>();
            var publishers                          = new List<Domain.Models.ApprovingAuthorityMember>();

            var documentRequestComments             = new List<Domain.Models.DocumentRequestComment>();
            var documentRequestApprovals            = new List<Domain.Models.DocumentRequestApproval>();

            if (documentRequest != null) {
                documentRequestSupportingDocuments = new DocumentRequestSupportingDocumentService().GetAllBy(a => a.DocumentRequestId == documentRequest.Id).ToList();
                documentRequestExternalDocuments   = new DocumentRequestExternalDocumentService().GetAllBy(a => a.DocumentRequestId == documentRequest.Id).ToList();
                approvers                          = new ApprovingAuthorityMemberService().GetMembers(documentRequest.ApproverSetId);
                reviewers                          = new ApprovingAuthorityMemberService().GetMembers(documentRequest.ReviewerSetId);
                publishers                         = new ApprovingAuthorityMemberService().GetMembers(documentRequest.PublisherSetId);
                documentRequestComments            = new DocumentRequestCommentService().GetAllComments(documentRequest.Id);
                documentRequestApprovals           = new DocumentRequestApprovalService().GetAllBy(a => a.DocumentRequestId == documentRequest.Id).ToList();
            }

            return View(new InformationManagementViewModel {
                TextEditor                          = (textEditor != null) ? textEditor.Value : "Default",
                DocumentRequest                     = documentRequest,
                DocumentRequestSupportingDocuments  = documentRequestSupportingDocuments,
                DocumentRequestComments             = documentRequestComments,
                DocumentRequestExternalDocuments    = documentRequestExternalDocuments,
                Approvers                           = approvers,
                Reviewers                           = reviewers,
                Publishers                          = publishers,
                DocumentRequestApprovals            = documentRequestApprovals,
                User                                = user,
                Employee                            = employee
            });
            
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult UploadContentFile(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestService().SaveUploadedFile(viewModel.DocumentRequest);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult Approve(Guid id, Guid employeeId) {
            try {
                new DocumentRequestApprovalService().Approve(id, employeeId);
                return Json("Approved", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestView)]
        public ActionResult ViewHtml(Guid id) {

            var documentRequest = new DocumentRequestService().Get(id);

            return View(new InformationManagementViewModel {
                Content = documentRequest.Content
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult Save(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestService().SaveAndGet(viewModel.DocumentRequest);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult Update(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestService().UpdateAndGet(viewModel.DocumentRequest);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [ValidateInput(false)]
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult UpdateContent(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestService().UpdateContent(viewModel.DocumentRequest);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [ValidateInput(false)]
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult UpdateContentRequest(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestService().UpdateContentRequest(viewModel.DocumentRequest);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult Submit(Guid id) {
            try {
                var data = new DocumentRequestService().Submit(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new DocumentRequestService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult GetAll() {
            try {
                var data = new DocumentRequestService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new DocumentRequestService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult SaveComment(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestCommentService().SaveAndGet(viewModel.DocumentRequestComment);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.DocumentRequestSave)]
        public JsonResult UploadFile(InformationManagementViewModel viewModel) {
            try {
                var data = new DocumentRequestSupportingDocumentService().SaveAndGet(viewModel.DocumentRequestSupportingDocument);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
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
    public class DocumentsController : BaseController {

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PublishedDocumentsView)]
        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var position = new EmployeePositionService().GetAllBy(a => a.EmployeeId == employee.Id && a.Tag == Domain.Models.EmployeePositionState.Active).FirstOrDefault();
            var documentRequest = new DocumentRequestService().GetAllBy(a => a.Tag == Domain.Models.DocumentRequestState.Publish || a.Tag == Domain.Models.DocumentRequestState.Revised).ToList();

            return View(new InformationManagementViewModel {
                DocumentRequests    = documentRequest,
                User                = CurrentUser(),
                Employee            = employee,
                Position            = (position == null) ? new Domain.Models.EmployeePosition {
                    DepartmentName  = "Blank"
                } : position
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PublishedDocumentsView)]
        public ActionResult View(Guid id) {
            var documentRequest = new DocumentRequestService().Get(id);
            var user            = CurrentUser();
            var employee        = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            return View(new InformationManagementViewModel {
                DocumentRequest             = documentRequest,
                DocumentRequestComments     = new DocumentRequestCommentService().GetAllBy(a => a.DocumentRequestId == documentRequest.Id).ToList(),
                Approvers                   = new ApprovingAuthorityMemberService().GetMembers(documentRequest.ApproverSetId),
                Reviewers                   = new ApprovingAuthorityMemberService().GetMembers(documentRequest.ReviewerSetId),
                Publishers                  = new ApprovingAuthorityMemberService().GetMembers(documentRequest.PublisherSetId),
                User                        = user,
                Employee                    = employee
            });
        }
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PublishedDocumentsSave)]
        public JsonResult Save(InformationManagementViewModel viewModel) {
            try {
                var data = new PublishedDocumentsService().SaveAndGet(viewModel.PublishedDocuments);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PublishedDocumentsDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new PublishedDocumentsService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PublishedDocumentsSave)]
        public JsonResult GetAll() {
            try {
                var data = new PublishedDocumentsService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.PublishedDocumentsView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new PublishedDocumentsService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
    }
}
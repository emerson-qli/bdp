using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.InformationManagement.Data {
    public class InformationManagementViewModel : BaseViewModel {


        public List<Domain.Models.DocumentRequest> DocumentRequests {
            get;
            set;
        }

        public Domain.Models.DocumentRequest DocumentRequest {
            get;
            set;
        }

        public List<Domain.Models.DocumentLog> DocumentLogs {
            get;
            set;
        }

        public Domain.Models.DocumentLog DocumentLog {
            get;
            set;
        }

        public List<Domain.Models.PublishedDocuments> PublishedDocument {
            get;
            set;
        }

        public Domain.Models.PublishedDocuments PublishedDocuments {
            get;
            set;
        }

        public Domain.Models.Organization Organization {
            get;
            set;
        }

        public List<Domain.Models.DocumentsForChangeRequests> DocumentsForChangeRequest {
            get;
            set;
        }

        public Domain.Models.DocumentsForChangeRequests DocumentsForChangeRequests {
            get;
            set;
        }


        public List<Domain.Models.DocumentSection> Documents {
            get;
            set;
        }

        public List<Domain.Models.ApprovingAuthorityMember> Approvers {
            get;
            set;
        }

        public List<Domain.Models.ApprovingAuthorityMember> Reviewers {
            get;
            set;
        }

        public List<Domain.Models.ApprovingAuthorityMember> Publishers {
            get;
            set;
        }

        public Domain.Models.EmployeePosition Position {
            get;
            set;
        }


        public List<Domain.Models.DocumentRequestComment> DocumentRequestComments {
            get;
            set;
        }

        public Domain.Models.DocumentRequestComment DocumentRequestComment {
            get;
            set;
        }
        public List<Domain.Models.DocumentRequestCommentAttachment> DocumentRequestCommentAttachments {
            get;
            set;
        }

        public Domain.Models.DocumentRequestCommentAttachment DocumentRequestCommentAttachment {
            get;
            set;
        }

        public List<Domain.Models.DocumentRequestSupportingDocument> DocumentRequestSupportingDocuments {
            get;
            set;
        }

        public Domain.Models.DocumentRequestSupportingDocument DocumentRequestSupportingDocument {
            get;
            set;
        }



        public List<Domain.Models.PublishedDocumentsComment> PublishedDocumentsComments {

            get;
            set;
        }


        public Domain.Models.PublishedDocumentsComment PublishedDocumentsComment {
            get;
            set;
        }
        
        public List<Domain.Models.DocumentsForChangeRequestsComment> DocumentsForChangeRequestsComments {
            get;
            set;
        }

        public Domain.Models.DocumentsForChangeRequestsComment DocumentsForChangeRequestsComment {
            get;
            set;
        }


        public List<Domain.Models.DocumentRequestApproval> DocumentRequestApprovals {
            get;
            set;
        }

        public Domain.Models.DocumentRequestApproval DocumentRequestApproval {
            get;
            set;
        }

        public string Content {
            get;
            set;
        }

        public Domain.Models.DocumentSetting DocumentSetting {
            get;
            set;
        }

        public List<Domain.Models.DocumentSetting> DocumentSettings {
            get;
            set;
        }

        public List<Domain.Models.DocumentRequestExternalDocument> DocumentRequestExternalDocuments {
            get;
            set;
        }

        public Domain.Models.DocumentRequestExternalDocument DocumentRequestExternalDocument {
            get;
            set;
        }

        public Domain.Models.Setting Setting {
            get;
            set;
        }

        public List<Domain.Models.Setting> Settings {
            get;
            set;
        }

        public string TextEditor {
            get;
            set;
        }

        public Domain.Models.ExternalDocument ExternalDocument {
            get;
            set;
        }

        public List<Domain.Models.ExternalDocument> ExternalDocuments {
            get;
            set;
        }
    }
}
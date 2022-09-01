using Domain.Models;
using Service.Helper;
using Service.Notification;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Document {
    public class DocumentRequestService : BaseService<Domain.Models.DocumentRequest, Domain.Repositories.DocumentRequestRepository> {

        public override DocumentRequest SaveAndGet(DocumentRequest entity) {
            
            var companyProfile      = new Service.Organization.OrganizationService().GetAll().FirstOrDefault();
            var documentRequest     = new DocumentRequestService().GetAll().ToList();
            int countRequest        = documentRequest.Count + 1;
            var documentType        = new DocumentGroupService().GetAllBy(a => a.Id == entity.DocumentTypeId).FirstOrDefault();

            int digits              = countRequest.ToString().Length + 2;
            string drcn             = countRequest.ToString().PadLeft(digits, '0');
            var yearNow             = DateTime.Now.Year.ToString();

            if (drcn.Length < 3) {
                drcn = drcn.Remove(0, 1);
            }

            if (entity != null) {
                entity.DCRN             = yearNow + '-' + entity.LevelName + '-' + drcn;
                entity.DocumentNumber   = companyProfile.Code.ToUpper() + '-' + documentType.DocumentTypePrefix + '-' + drcn;
            }

            var data = base.SaveAndGet(entity);
            return data;
        }

        public override DocumentRequest UpdateAndGet(DocumentRequest entity) {
            var data = base.Get(entity.Id);

            if(data != null) {
                entity.Content          = data.Content;
                entity.UniqueFileName   = data.UniqueFileName;
                entity.OriginalFileName = data.OriginalFileName;
                entity.DocumentNumber   = data.DocumentNumber;
                entity.RevisionNo       = data.RevisionNo;
            }
            

            return base.UpdateAndGet(entity);
        }

        public DocumentRequest Submit(Guid id) {
            var entity          = base.Get(id);
            if (entity != null) {
                if (entity.Tag == DocumentRequestState.Draft) {
                    entity.Tag = DocumentRequestState.Submit;
                    entity.UpdatedAt = DateTime.Now;
                } else if (entity.Tag == DocumentRequestState.DraftRevision) {
                    entity.Tag = DocumentRequestState.SubmitRevision;
                    entity.UpdatedAt = DateTime.Now;
                } else {
                    entity.Tag = DocumentRequestState.SubmitObsoletion;
                    entity.UpdatedAt = DateTime.Now;
                }

            }
            var data = base.UpdateAndGet(entity);
            new DocumentRequestApprovalService().Initiate(entity);
            new NotificationService().Initiate(entity);

            if (entity.Content != null) {
                new PDFHelper().GeneratePDF(entity.Content, entity.Id, entity.Name, string.Empty, string.Empty);
            }

            return data;
        }

        
        public Domain.Models.DocumentRequest UpdateContentRequest(DocumentRequest documentRequest) {

            var entity = base.Get(documentRequest.Id);
            if (entity != null) {
                entity.Content   = documentRequest.Content;
                entity.UpdatedAt = DateTime.Now;
                entity.Tag       = DocumentRequestState.Draft;
                base.SaveAndGet(entity);
            }

            return entity;

        }


        public Domain.Models.DocumentRequest UpdateContent(DocumentRequest documentRequest) {

            var entity = base.Get(documentRequest.Id);
            if(entity != null) {
                entity.SupportingDocuments               = documentRequest.SupportingDocuments;
                entity.DocumentRequestExternalDocuments  = documentRequest.DocumentRequestExternalDocuments;
                entity.Content                           = documentRequest.Content;
                entity.UpdatedAt                         = DateTime.Now;
                base.UpdateAndGet(entity);
            }

            return entity;

        }


        public void Publish(Guid id) {

            var entity = base.Get(id);
            var document = new DocumentRequestService().GetAllBy(a => a.DocumentNumber == entity.DocumentNumber).FirstOrDefault();

            if(entity != null) {
                if (entity.Tag == DocumentRequestState.SubmitRevision) {
                    entity.Tag = DocumentRequestState.Revised;
                    entity.RevisionNo += 1;

                    if (document != null) {
                        new DocumentRequestService().DeleteDocument(entity.DocumentNumber);
                    }

                } else if (entity.Tag == DocumentRequestState.SubmitObsoletion) {
                    entity.Tag = DocumentRequestState.Obsolete;

                    if (document != null) {
                        new DocumentRequestService().DeleteDocument(entity.DocumentNumber);
                    }
                } else {
                    entity.Tag = DocumentRequestState.Publish;
                }
                entity.UpdatedAt = DateTime.Now;
                base.Update(entity);
            }

        }

        public void DuplicateDocumentRequest(Guid id) {

            var entity              = Repository.AllIncluding(a => a.SupportingDocuments).Where(a => a.Id == id).FirstOrDefault();
            var comments            = new DocumentRequestCommentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var approvals           = new DocumentRequestApprovalService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var externalDocuments   = new DocumentRequestExternalDocumentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var supportingFiles     = new DocumentRequestSupportingDocumentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var commentsAttachments = new DocumentRequestCommentAttachmentService().GetAllBy(a => a.DocumentRequestId == id).ToList();

            var documentRequest     = new DocumentRequestService().GetAll().ToList();
            int countRequest        = documentRequest.Count + 1;
            int digits              = countRequest.ToString().Length + 2;
            string drcn             = countRequest.ToString().PadLeft(digits, '0');
            var yearNow             = DateTime.Now.Year.ToString();


            if (drcn.Length < 3) {
                drcn = drcn.Remove(0, 1);
            }

            if (entity != null) {

                var newDocumentRequestId = Guid.NewGuid();

                var newEntity = new Domain.Models.DocumentRequest {
                    Id                               = newDocumentRequestId,
                    ApproverSetId                    = entity.ApproverSetId,
                    ApproverSetName                  = entity.ApproverSetName,
                    Content                          = entity.Content,
                    DCRN                             = yearNow + '-' + entity.LevelName + '-' + drcn,
                    DepartmentId                     = entity.DepartmentId,
                    DepartmentName                   = entity.DepartmentName,
                    DocumentCategoryId               = entity.DocumentCategoryId,
                    DocumentCategoryName             = entity.DocumentCategoryName,
                    DocumentControlNumber            = entity.DocumentControlNumber,
                    DocumentNumber                   = entity.DocumentNumber,
                    DocumentTypeId                   = entity.DocumentTypeId,
                    DocumentTypeName                 = entity.DocumentTypeName,
                    EmployeeId                       = entity.EmployeeId,
                    EmployeeName                     = entity.EmployeeName,
                    GeneralStatusDescription         = entity.GeneralStatusDescription,
                    LevelId                          = entity.LevelId,
                    LevelName                        = entity.LevelName,
                    Name                             = entity.Name,
                    AccessLevelId                    = entity.AccessLevelId,
                    AccessLevelName                  = entity.AccessLevelName,
                    OrganizationManagementSystemId   = entity.OrganizationManagementSystemId,
                    OrganizationManagementSystemName = entity.OrganizationManagementSystemName,
                    PublisherSetId                   = entity.PublisherSetId,
                    PublisherSetName                 = entity.PublisherSetName,
                    Purpose                          = entity.Purpose,
                    QualificationId                  = entity.QualificationId,
                    QualificationName                = entity.QualificationName,
                    ReviewerSetId                    = entity.ReviewerSetId,
                    ReviewerSetName                  = entity.ReviewerSetName,
                    ReviewPeriod                     = entity.ReviewPeriod,
                    SectionId                        = entity.SectionId,
                    SectionName                      = entity.SectionName,
                    OriginalFileName                 = entity.OriginalFileName,
                    UniqueFileName                   = entity.UniqueFileName,
                    RevisionNo                       = entity.RevisionNo,
                    Tag                              = DocumentRequestState.DraftRevision
                };

                base.Save(newEntity);

                var newCommentId = Guid.NewGuid();
                var newComments  = new List<Domain.Models.DocumentRequestComment>();
                comments.ForEach(a => {
                    newComments.Add(new DocumentRequestComment {
                        Id                  = newCommentId,
                        Comment             = a.Comment,
                        Attachments         = a.Attachments,
                        DocumentRequestId   = newDocumentRequestId,
                        EmployeeId          = a.EmployeeId,
                        EmployeeName        = a.EmployeeName,
                        UpdatedAt           = a.UpdatedAt,
                        Order               = a.Order
                    });
                });
                new DocumentRequestCommentService().Save(newComments);

                var newExternalDocuments = new List<Domain.Models.DocumentRequestExternalDocument>();
                externalDocuments.ForEach(a => {
                    newExternalDocuments.Add(new DocumentRequestExternalDocument { 
                        Id                                  = Guid.NewGuid(),
                        DocumentRequestId                   = newDocumentRequestId,
                        ExternalDocumentOriginalFileName    = a.ExternalDocumentOriginalFileName,
                        ExternalDocumentUniqueFileName      = a.ExternalDocumentUniqueFileName,
                    });
                });
                new DocumentRequestExternalDocumentService().Save(newExternalDocuments);

                var newSupportingFiles = new List<Domain.Models.DocumentRequestSupportingDocument>();
                supportingFiles.ForEach(a => {
                    newSupportingFiles.Add(new DocumentRequestSupportingDocument {
                        Id                  = Guid.NewGuid(),
                        DocumentRequestId   = newDocumentRequestId,
                        OriginalFileName    = a.OriginalFileName,
                        UniqueFileName      = a.UniqueFileName
                    }); 
                });
                new DocumentRequestSupportingDocumentService().Save(newSupportingFiles);

                var newCommentsAttachments = new List<Domain.Models.DocumentRequestCommentAttachment>();
                commentsAttachments.ForEach(a => {
                    newCommentsAttachments.Add(new DocumentRequestCommentAttachment {
                        Id                       = Guid.NewGuid(),
                        DocumentRequestCommentId = newCommentId,
                        DocumentRequestId        = newDocumentRequestId,
                        OrginalFileName          = a.OrginalFileName,
                        UniqueFileName           = a.UniqueFileName
                    });
                });
                new DocumentRequestCommentAttachmentService().Save(newCommentsAttachments);
                
            }

        }

        public void RequestForObsoletion(Guid id) {

            var entity              = Repository.AllIncluding(a => a.SupportingDocuments).Where(a => a.Id == id).FirstOrDefault();
            var comments            = new DocumentRequestCommentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var approvals           = new DocumentRequestApprovalService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var externalDocuments   = new DocumentRequestExternalDocumentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var supportingFiles     = new DocumentRequestSupportingDocumentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            var commentsAttachments = new DocumentRequestCommentAttachmentService().GetAllBy(a => a.DocumentRequestId == id).ToList();
            
            var documentRequest     = new DocumentRequestService().GetAll().ToList();
            int countRequest        = documentRequest.Count + 1;
            int digits              = countRequest.ToString().Length + 2;
            string drcn             = countRequest.ToString().PadLeft(digits, '0');
            var yearNow             = DateTime.Now.Year.ToString();


            if (drcn.Length < 3) {
                drcn = drcn.Remove(0, 1);
            }


            if (entity != null) {

                var newDocumentRequestId = Guid.NewGuid();

                var newEntity = new Domain.Models.DocumentRequest {
                    Id                               = newDocumentRequestId,
                    ApproverSetId                    = entity.ApproverSetId,
                    ApproverSetName                  = entity.ApproverSetName,
                    Content                          = entity.Content,
                    DCRN                             = yearNow + '-' + entity.LevelName + '-' + drcn,
                    DepartmentId                     = entity.DepartmentId,
                    DepartmentName                   = entity.DepartmentName,
                    DocumentCategoryId               = entity.DocumentCategoryId,
                    DocumentCategoryName             = entity.DocumentCategoryName,
                    DocumentNumber                   = entity.DocumentNumber,
                    DocumentControlNumber            = entity.DocumentControlNumber,
                    DocumentTypeId                   = entity.DocumentTypeId,
                    DocumentTypeName                 = entity.DocumentTypeName,
                    EmployeeId                       = entity.EmployeeId,
                    EmployeeName                     = entity.EmployeeName,
                    GeneralStatusDescription         = entity.GeneralStatusDescription,
                    LevelId                          = entity.LevelId,
                    LevelName                        = entity.LevelName,
                    Name                             = entity.Name,
                    AccessLevelId                    = entity.AccessLevelId,
                    AccessLevelName                  = entity.AccessLevelName,
                    OrganizationManagementSystemId   = entity.OrganizationManagementSystemId,
                    OrganizationManagementSystemName = entity.OrganizationManagementSystemName,
                    PublisherSetId                   = entity.PublisherSetId,
                    PublisherSetName                 = entity.PublisherSetName,
                    Purpose                          = entity.Purpose,
                    QualificationId                  = entity.QualificationId,
                    QualificationName                = entity.QualificationName,
                    ReviewerSetId                    = entity.ReviewerSetId,
                    ReviewerSetName                  = entity.ReviewerSetName,
                    ReviewPeriod                     = entity.ReviewPeriod,
                    OriginalFileName                 = entity.OriginalFileName,
                    UniqueFileName                   = entity.UniqueFileName,
                    SectionId                        = entity.SectionId,
                    SectionName                      = entity.SectionName,
                    Tag                              = DocumentRequestState.DraftObsoletion
                };

                base.Save(newEntity);

                var newCommentId = Guid.NewGuid();
                var newComments  = new List<Domain.Models.DocumentRequestComment>();
                comments.ForEach(a => {
                    newComments.Add(new DocumentRequestComment {
                        Id                  = newCommentId,
                        Comment             = a.Comment,
                        Attachments         = a.Attachments,
                        DocumentRequestId   = newDocumentRequestId,
                        EmployeeId          = a.EmployeeId,
                        EmployeeName        = a.EmployeeName,
                        UpdatedAt           = a.UpdatedAt,
                        Order               = a.Order
                    });
                });
                new DocumentRequestCommentService().Save(newComments);

                var newExternalDocuments = new List<Domain.Models.DocumentRequestExternalDocument>();
                externalDocuments.ForEach(a => {
                    newExternalDocuments.Add(new DocumentRequestExternalDocument {
                        Id                                  = Guid.NewGuid(),
                        DocumentRequestId                   = newDocumentRequestId,
                        ExternalDocumentOriginalFileName    = a.ExternalDocumentOriginalFileName,
                        ExternalDocumentUniqueFileName      = a.ExternalDocumentUniqueFileName,
                    });
                });
                new DocumentRequestExternalDocumentService().Save(newExternalDocuments);

                var newSupportingFiles = new List<Domain.Models.DocumentRequestSupportingDocument>();
                supportingFiles.ForEach(a => {
                    newSupportingFiles.Add(new DocumentRequestSupportingDocument {
                        Id                  = Guid.NewGuid(),
                        DocumentRequestId   = newDocumentRequestId,
                        OriginalFileName    = a.OriginalFileName,
                        UniqueFileName      = a.UniqueFileName
                    });
                });
                new DocumentRequestSupportingDocumentService().Save(newSupportingFiles);

                var newCommentsAttachments = new List<Domain.Models.DocumentRequestCommentAttachment>();
                commentsAttachments.ForEach(a => {
                    newCommentsAttachments.Add(new DocumentRequestCommentAttachment {
                        Id                          = Guid.NewGuid(),
                        DocumentRequestCommentId    = newCommentId,
                        DocumentRequestId           = newDocumentRequestId,
                        OrginalFileName             = a.OrginalFileName,
                        UniqueFileName              = a.UniqueFileName
                    });
                });
                new DocumentRequestCommentAttachmentService().Save(newCommentsAttachments);


            }

        }

        public DocumentRequest SaveUploadedFile(DocumentRequest documentRequest) {

            var entity = base.Get(documentRequest.Id);

            if (entity != null) {
                entity.UniqueFileName   = documentRequest.UniqueFileName;
                entity.OriginalFileName = documentRequest.OriginalFileName;
            }

            return base.UpdateAndGet(entity);
        }

        public void DeleteDocument(string documentNumber) {
            var data = new DocumentRequestService().GetAllBy(a => a.DocumentNumber == documentNumber).ToList();

            if (data != null) {
                for (int i = 0; i < data.Count; i++) {
                    if (data[i].Tag == DocumentRequestState.Publish) {
                        new DocumentRequestService().Delete(data[i].Id);
                    }
                }
            }

        }


    }
}

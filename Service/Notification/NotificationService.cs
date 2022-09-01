using Domain.Models;
using Service.ApprovingAuthority;
using Service.Audit;
using Service.Organization;
using Service.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Notification {
    public class NotificationService : BaseService<Domain.Models.Notification, Domain.Repositories.NotificationRepository> {
        public void Initiate(DocumentRequest entity) {

            var reviewers   = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == entity.ReviewerSetId).ToList();
            //var publishers  = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == entity.PublisherSetId).ToList();
            //var approvers   = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == entity.ApproverSetId).ToList();
            var notifications = new List<Domain.Models.Notification>();
            
            foreach(var reviewer in reviewers) {
                notifications.Add(new Domain.Models.Notification {
                     Description    = entity.Name + "- New Document Request for review",
                     Link           = "/InformationManagement/DocumentRequests/View/" + entity.Id,
                     Type           = NotificationType.DocumentRequestForReview,
                     UserFullName   = reviewer.EmployeeName,
                     UserId         = reviewer.EmployeeId,
                     Tag            = NotificationState.New
                });
            }
            
            //foreach(var approver in approvers) {
            //    notifications.Add(new Domain.Models.Notification {
            //         Description    = entity.Name + "- New Document Request for approval",
            //         Link           = "/InformationManagement/DocumentRequests/View/" + entity.Id,
            //         Type           = NotificationType.DocumentRequestForApproval,
            //         UserFullName   = approver.EmployeeName,
            //         UserId         = approver.EmployeeId,
            //         Tag            = NotificationState.New
            //    });
            //}
            
            //foreach(var publisher in publishers) {
            //    notifications.Add(new Domain.Models.Notification {
            //         Description    = entity.Name + "- New Document Request for publishing",
            //         Link           = "/InformationManagement/DocumentRequests/View/" + entity.Id,
            //         Type           = NotificationType.DocumentRequestForPublish,
            //         UserFullName   = publisher.EmployeeName,
            //         UserId         = publisher.EmployeeId,
            //         Tag            = NotificationState.New
            //    });
            //}

            base.Save(notifications);
        }

        public void InitiateNextApprovers(Guid setId, DocumentRequest entity) {

            var s = new ApprovingAuthorityService().Get(setId);
            var nextSet = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == setId).ToList();
            var notifications = new List<Domain.Models.Notification>();
            

            foreach (var set in nextSet) {
                var type = NotificationType.DocumentRequestForReview;
                var message = "review";
                if(s.Tag == ApprovingAuthorityState.Approver) {
                    type = NotificationType.DocumentRequestForApproval;
                    message = "approval";
                }else if(s.Tag == ApprovingAuthorityState.Publisher) {
                    type = NotificationType.DocumentRequestForPublish;
                    message = "publishing";
                }
                notifications.Add(new Domain.Models.Notification {
                     Description    = entity.Name + "- New Document Request for " + message,
                     Link           = "/InformationManagement/DocumentRequests/View/" + entity.Id,
                     Type           = type,
                     UserFullName   = set.EmployeeName,
                     UserId         = set.EmployeeId,
                     Tag            = NotificationState.New
                });
            }

            base.Save(notifications);

        }

        public void Read(Guid id) {

            var entity = base.Get(id);
            if(entity != null) {
                entity.Tag = NotificationState.Read;
                entity.UpdatedAt = DateTime.Now;
                base.Update(entity);
            }


        }

        public void InitiateAuditPlan(Guid id) {
            var auditors        = new AuditApprovalService().GetAllBy(a => a.AuditPlanId == id).ToList();
            var newNotification = new List<Domain.Models.Notification>();

            foreach (var auditor in auditors) {
                newNotification.Add(new Domain.Models.Notification {
                    Description         = auditor.AuditName + "- New Audit Plan for review",
                    Link                = "/AuditManagement/InternalAudit/View/" + auditor.AuditPlanId,
                    Type                = NotificationType.AuditPlanForApproval,
                    UserFullName        = auditor.AuditName,
                    UserId              = auditor.AuditorId,
                    Tag                 = NotificationState.New
                });
            }

            base.Save(newNotification);
        }

        public void ExpiringDocument(Guid id, Guid userId, string userName) {
            var documents = new OrganizationComplianceService().GetAllBy(a => a.Id == id).FirstOrDefault();
            var newNotification = new Domain.Models.Notification();

            if (documents != null) {
                newNotification.Description     = documents.Name + "- is 3 days before expiration or it is already expired.";
                newNotification.Link            = "/Organization/Profile/#nav-oc" + documents.Id;
                newNotification.Type            = NotificationType.ExpiringDocument;
                newNotification.UserFullName    = userName;
                newNotification.UserId          = userId;
                newNotification.Tag             = NotificationState.New;

                base.Save(newNotification);
            }
        }

        public void GetExpiringDocuments() {
            var documents           = new OrganizationComplianceService().GetAll().ToList();
            var certificates        = new OrganizationComplianceCertificateService().GetAll().ToList();
            var settings            = new SettingService().GetAll().ToList();
            var settingsRecipients  = new Domain.Models.Setting();
            var newNotification     = new List<Domain.Models.Notification>();

            int x           = 0;
            int threshold   = 0;

            for (var c = 0; c < settings.Count; c++) {
                if (settings[c].Name == "Threshold for expiring documents") {
                    settingsRecipients = new SettingService().GetAllIncludingRecipients(settings[c].Id).FirstOrDefault();
                    var lookInt = settingsRecipients.Value.TrimEnd('d', 'a', 'y', 's', ' ');

                    threshold = Int32.Parse(lookInt);
                } else {
                    x = 0;
                }
            }

            x = threshold;


            if (documents.Count != 0) {
                for (int i = 0; i < documents.Count; i++) {
                    DateTime expirationDate  = documents[i].ExpirationDate.AddDays(x);
                    DateTime dateNow         = DateTime.Now;
                    int compareDate          = DateTime.Compare(dateNow, expirationDate);
                    
                    if (compareDate < 0) {
                       // result = "is earlier than";
                    } else if (compareDate == 0) {
                       // result = "is the same time as";
                    } else {
                        // result = "is later than";
                        for (var z = 0; z < settingsRecipients.EmployeeRecipients.Count; z++) {

                            newNotification.Add(new Domain.Models.Notification {
                                Description         = documents[i].Name + " - is expiring, please kindly check",
                                Link                = "/Organization/Profile#nav-cr",
                                Type                = NotificationType.ExpiringDocument,
                                UserFullName        = settingsRecipients.EmployeeRecipients[z].EmployeeName,
                                UserId              = settingsRecipients.EmployeeRecipients[z].EmployeeId,
                                Tag                 = NotificationState.New
                            });

                        }
                    }
                }
            }

            if (certificates.Count != 0) {
                for (int i = 0; i < certificates.Count; i++) {
                    DateTime expirationDate = certificates[i].ExpirationDate.AddDays(x);
                    DateTime dateNow        = DateTime.Now;
                    int compareDate         = DateTime.Compare(dateNow, expirationDate);

                    if (compareDate < 0) {
                        // result = "is earlier than";
                    } else if (compareDate == 0) {
                        // result = "is the same time as";
                    } else {
                        // result = "is later than";
                        for (var z = 0; z < settingsRecipients.EmployeeRecipients.Count; z++) {

                            newNotification.Add(new Domain.Models.Notification {
                                Description = certificates[i].Name + " - is expiring, please kindly check",
                                Link = "/Organization/Profile#nav-cr",
                                Type = NotificationType.ExpiringDocument,
                                UserFullName = settingsRecipients.EmployeeRecipients[z].EmployeeName,
                                UserId = settingsRecipients.EmployeeRecipients[z].EmployeeId,
                                Tag = NotificationState.New
                            });

                        }
                    }
                }
            }


            base.Save(newNotification);
        }
    }
}

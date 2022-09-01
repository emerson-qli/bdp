using Domain.Models;
using Service.ApprovingAuthority;
using Service.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Document {
    public class DocumentRequestApprovalService : BaseService<Domain.Models.DocumentRequestApproval, Domain.Repositories.DocumentRequestApprovalRepository> {
        public void Initiate(DocumentRequest entity) {

            var approvers   = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == entity.ApproverSetId).ToList();
            var publishers  = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == entity.PublisherSetId).ToList();
            var reviewers   = new ApprovingAuthorityMemberService().GetAllBy(a => a.ApprovingAuthorityId == entity.ReviewerSetId).ToList();

            var documentRequestApprovals = new List<Domain.Models.DocumentRequestApproval>();

            foreach(var approver in approvers) {
                documentRequestApprovals.Add(new DocumentRequestApproval {
                     ApprovingAuthorityId = approver.ApprovingAuthorityId,
                     ApprovingAuthoryName = entity.ApproverSetName,
                     DocumentRequestId    = entity.Id,
                     DocumentRequestName  = entity.Name,
                     EmployeeId           = approver.EmployeeId,
                     EmployeeName         = approver.EmployeeName,
                     EmployeePosition     = approver.EmployeePosition,
                     Order                = 1,
                     Tag                  = DocumentRequestApprovalState.Initiated
                });
            }
            
            foreach(var publisher in publishers) {
                documentRequestApprovals.Add(new DocumentRequestApproval {
                     ApprovingAuthorityId = publisher.ApprovingAuthorityId,
                     ApprovingAuthoryName = entity.ApproverSetName,
                     DocumentRequestId    = entity.Id,
                     DocumentRequestName  = entity.Name,
                     EmployeeId           = publisher.EmployeeId,
                     EmployeeName         = publisher.EmployeeName,
                     EmployeePosition     = publisher.EmployeePosition,
                     Order                = 2,
                     Tag                  = DocumentRequestApprovalState.Initiated
                });
            }
            
            foreach(var reviewer in reviewers) {
                documentRequestApprovals.Add(new DocumentRequestApproval {
                     ApprovingAuthorityId = reviewer.ApprovingAuthorityId,
                     ApprovingAuthoryName = entity.ApproverSetName,
                     DocumentRequestId    = entity.Id,
                     DocumentRequestName  = entity.Name,
                     EmployeeId           = reviewer.EmployeeId,
                     EmployeeName         = reviewer.EmployeeName,
                     EmployeePosition     = reviewer.EmployeePosition,
                     Order                = 0,
                     Tag                  = DocumentRequestApprovalState.ForApproval
                });
            }

            base.Save(documentRequestApprovals);

        }

        public void Approve(Guid id, Guid employeeId) {

            var entity = base.GetAllBy(a => a.DocumentRequestId == id && a.EmployeeId == employeeId && a.Tag == DocumentRequestApprovalState.ForApproval).FirstOrDefault();
            if(entity != null) {
                entity.Tag          = DocumentRequestApprovalState.Approved;
                entity.UpdatedAt    = DateTime.Now;
                base.Update(entity);

                if (entity.EmployeePosition == "Team Lead") {

                    //team lead approved, so set all approvers to auto approved.
                    var allInLevel      = base.GetAllBy(a => a.DocumentRequestId == id && a.ApprovingAuthorityId == entity.ApprovingAuthorityId).ToList();
                    var levelList       = new List<Domain.Models.DocumentRequestApproval>();
                    var currentOrder    = allInLevel.FirstOrDefault().Order;
                    allInLevel.ForEach(a => {
                        a.Tag           = DocumentRequestApprovalState.Approved;
                        a.UpdatedAt     = DateTime.Now;
                        levelList.Add(a);
                    });

                    base.Update(levelList);

                    //initiate next approvers

                    //set next group to for approval state
                    var documentRequest = new DocumentRequestService().Get(id);
                    var nextOrder       = currentOrder + 1;
                    var allInextLevel   = base.GetAllBy(a => a.DocumentRequestId == id && a.Order == nextOrder).ToList();
                    var nextLevelList   = new List<Domain.Models.DocumentRequestApproval>();

                    if(allInextLevel.Count > 0) {
                        new NotificationService().InitiateNextApprovers(allInextLevel.FirstOrDefault().ApprovingAuthorityId, documentRequest);

                        allInextLevel.ForEach(a => {
                            a.Tag           = DocumentRequestApprovalState.ForApproval;
                            a.UpdatedAt     = DateTime.Now;
                            nextLevelList.Add(a);
                        });

                        base.Update(nextLevelList);
                    }else {
                        new DocumentRequestService().Publish(id);
                    }

                }


            }

            

        }
    }
}

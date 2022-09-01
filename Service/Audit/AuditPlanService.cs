using Domain.Models;
using Service.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Audit {
    public class AuditPlanService : BaseService<Domain.Models.AuditPlan, Domain.Repositories.AuditPlanRepository> {
        public AuditPlan UpdateAuditPlan(Domain.Models.AuditPlan auditPlan) {
            var entity = base.Get(auditPlan.Id);
            if (entity != null) {
                entity.Name                         = auditPlan.Name;
                entity.Criteria                     = auditPlan.Criteria;
                entity.Description                  = auditPlan.Description;
                entity.Objective                    = auditPlan.Objective;
                entity.AuditPlanAuditors            = auditPlan.AuditPlanAuditors;
            }
            base.UpdateAndGet(entity);
            return entity;
        }

        public List<AuditPlan> GetAllIncluding() {
            var entity = Repository.AllIncluding(a => a.AuditPlanAuditors, a => a.AuditPlanSupportingDocuments, a => a.AuditSchedules).Where(a => a.Tag == AuditPlanState.Audited).ToList();

            return entity;
        }

        public List<AuditPlan> GetAllAudits() {
            var entity = Repository.AllIncluding(a => a.AuditPlanAuditors, a => a.AuditPlanSupportingDocuments, a => a.AuditSchedules).ToList();

            return entity;
        }

        public void Submit(Guid id) {
            var entity   = Repository.AllIncluding(a => a.AuditPlanAuditors, a => a.AuditPlanSupportingDocuments).Where(a => a.Id == id).FirstOrDefault();
            var auditors = new AuditPlanAuditorService().GetAllBy(a => a.AuditPlanId == entity.Id).ToList();
            

            if (entity.AuditPlanAuditors.Count != 0) {
                entity.Tag                  = AuditPlanState.InProgress;
                entity.UpdatedAt            = DateTime.Now;
                base.UpdateAndGet(entity);

                var auditApproval = new List<Domain.Models.AuditApproval>();
                auditors.ForEach(a => {
                    auditApproval.Add(new AuditApproval {
                        Id              = Guid.NewGuid(),
                        AuditPlanId     = entity.Id,
                        AuditName       = entity.Name,
                        AuditorId       = a.AuditorId,
                        AuditorName     = a.AuditorName,
                        UpdatedAt       = DateTime.Now,
                        Tag             = AuditApprovalState.Initiated
                    });
                });
                
                new AuditApprovalService().Save(auditApproval);
                new NotificationService().InitiateAuditPlan(entity.Id);

            }

            



        }

        internal void Approve(Guid id) {
            var entity = base.Get(id);
            if (entity != null) {
                entity.Tag = AuditPlanState.Audited;
                entity.UpdatedAt = DateTime.Now;
                base.Update(entity);
            }
        }

        public AuditPlan SaveSupportingFile(AuditPlan auditPlan) {
            var entity = base.Get(auditPlan.Id);
            if (entity != null) {
                entity.AuditPlanSupportingDocuments = auditPlan.AuditPlanSupportingDocuments;
            }
            base.UpdateAndGet(entity);
            return entity;
        }

        public AuditPlan GetAll(Guid id) {

            var entity = base.Get(id);
            if (entity != null) {
                entity.AuditPlanAuditors = new AuditPlanAuditorService().GetAllBy(a => a.AuditPlanId == entity.Id).ToList();
                entity.AuditSchedules    = new AuditScheduleService().GetAllBy(a => a.AuditPlanId == entity.Id).ToList();
                entity.AuditPlanSupportingDocuments = new AuditPlanSupportingDocumentService().GetAllBy(a => a.AuditPlanId == entity.Id).ToList();

            }
            return entity;
        }

        public AuditPlan SaveSchedule(AuditPlan auditPlan) {
            var entity = base.Get(auditPlan.Id);
            if (entity != null) {
                entity.AuditSchedules = auditPlan.AuditSchedules;
            }
            base.UpdateAndGet(entity);
            return entity;
        }

        public object SaveAuditors(AuditPlan auditPlan) {
            var entity = base.Get(auditPlan.Id);

            if (entity != null) {
                entity.AuditPlanAuditors = auditPlan.AuditPlanAuditors;
            }
            base.UpdateAndGet(entity);
            return entity;
        }
    }
}


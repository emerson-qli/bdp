using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Audit {
    public class AuditApprovalService : BaseService<Domain.Models.AuditApproval, Domain.Repositories.AuditApprovalRepository> {
        public void ApproveAudit(Guid id, Guid employeeId) {
            var entity = base.GetAllBy(a => a.AuditPlanId == id && a.AuditorId == employeeId).FirstOrDefault();

            if (entity != null) {
                entity.Tag       = AuditApprovalState.Approved;
                entity.UpdatedAt = DateTime.Now;
                new AuditApprovalService().Update(entity);
            }

            var auditPlan   = new AuditPlanService().Get(a => a.Id == id);
            var allAuditors = base.GetAllBy(a => a.AuditPlanId == id && a.Tag == AuditApprovalState.Initiated).ToList();

            if (allAuditors.Count == 0) {
                new AuditPlanService().Approve(id);
            } 

        }
    }
}

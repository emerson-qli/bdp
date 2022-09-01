using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Audit {
    public class AuditService : BaseService<Domain.Models.Audit, Domain.Repositories.AuditRepository> {
        public List<Domain.Models.Audit> GetAllIncluding(Guid id) {
            var entities = Repository.AllIncluding(a => a.ManagementSystems)
                                     .Where(a => a.AuditProgramId == id)
                                     .ToList();

            return entities;
        }

        public Domain.Models.Audit GetAudit(Guid id) {

            var entities = Repository.AllIncluding(a => a.ManagementSystems, a => a.AuditPlans)
                                     .Where(a => a.AuditProgramId == id)
                                     .FirstOrDefault();

            var entity = base.Get(entities.Id);
            if (entity != null) {
                entity.ManagementSystems    = new AuditOrganizationManagementSystemService().GetAllBy(a => a.AuditId == entity.Id).ToList();
                entity.AuditPlans           = new AuditPlanService().GetAllBy(a => a.AuditId == entity.Id).ToList();
                entity.BusinessProcesses    = new AuditOrganizationBusinessProcessService().GetAllBy(a => a.AuditId == entity.Id).ToList();

            }
            return entity;

        }

        public Domain.Models.Audit SaveMStype(Domain.Models.Audit audit) {
            var entity = base.Get(audit.Id);

            if (entity != null) {
                entity.ManagementSystems = audit.ManagementSystems;
                base.UpdateAndGet(entity);
            }

            return entity;
        }


        public Domain.Models.Audit UpdateSchedule(Domain.Models.Audit audit) {
            var entity = base.Get(audit.Id);

            if (entity != null) {
                entity.StartDate    = audit.StartDate;
                entity.EndDate      = audit.EndDate;
                base.UpdateAndGet(entity);
            }

            return entity;
        }

        public Domain.Models.Audit NewAuditPlan(Domain.Models.Audit audit) {
            var entity = base.Get(audit.Id);
            if (entity != null) {
                entity.AuditPlans   = audit.AuditPlans;
                base.UpdateAndGet(entity);
            }

            return entity;
        }

        public Domain.Models.Audit SaveProcess(Domain.Models.Audit audit) {
            var entity = base.Get(audit.Id);

            if (entity != null) {
                entity.BusinessProcesses = audit.BusinessProcesses;
                base.UpdateAndGet(entity);
            }

            return entity;
        }

        public Domain.Models.Audit GetAllAudited(Guid id) {
            var entity = Repository.AllIncluding(a => a.AuditPlans)
                                   .Where(a => a.AuditProgramId == id)
                                   .FirstOrDefault();
            if (entity != null) {
                entity.AuditPlans = new AuditPlanService().GetAllBy(a => a.AuditId == entity.Id && a.Tag == Domain.Models.AuditPlanState.Audited).ToList();
            }

            return entity;
        }
    }
}   


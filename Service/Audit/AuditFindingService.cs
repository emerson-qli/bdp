using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Audit {
    public class AuditFindingService : BaseService<Domain.Models.AuditFinding, Domain.Repositories.AuditFindingRepository> {
        public List<AuditFinding> GetFinding(Guid id) {
            var entity = base.GetAllBy(a => a.AuditPlanId == id).ToList();

            return entity;
        }
    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditPlanAuditorRepository : BaseRepository<BPHDbContext, AuditPlanAuditor>, IAuditPlanAuditorRepository {
    }

    public interface IAuditPlanAuditorRepository : IBaseRepository<AuditPlanAuditor> {

    }
}

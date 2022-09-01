using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditPlanRepository : BaseRepository<BPHDbContext, AuditPlan>, IAuditPlanRepository {
    }

    public interface IAuditPlanRepository : IBaseRepository<AuditPlan> {

    }
}

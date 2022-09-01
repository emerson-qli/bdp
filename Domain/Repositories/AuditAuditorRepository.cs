using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditAuditorRepository : BaseRepository<BPHDbContext, AuditAuditor>, IAuditAuditorRepository {
    }

    public interface IAuditAuditorRepository : IBaseRepository <AuditAuditor> {

    }
}

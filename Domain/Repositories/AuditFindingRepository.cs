using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditFindingRepository : BaseRepository<BPHDbContext, AuditFinding>, IAuditFindingRepository {
    }

    public interface IAuditFindingRepository : IBaseRepository<AuditFinding> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditUniverseRepository : BaseRepository<BPHDbContext, AuditUniverse>, IAuditUniverseRepository {

    }

    public interface IAuditUniverseRepository : IBaseRepository<AuditUniverse> {

    }
}

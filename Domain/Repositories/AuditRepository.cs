using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditRepository : BaseRepository<BPHDbContext, Audit>, IAuditRepository {

    }

    public interface IAuditRepository : IBaseRepository<Audit> {

    }
}

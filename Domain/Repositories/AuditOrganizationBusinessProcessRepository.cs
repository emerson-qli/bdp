using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditOrganizationBusinessProcessRepository : BaseRepository<BPHDbContext, AuditOrganizationBusinessProcess>, IAuditOrganizationBusinessProcessRepository {
    }

    public interface IAuditOrganizationBusinessProcessRepository : IBaseRepository<AuditOrganizationBusinessProcess> {

    }
}


using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditOrganizationManagementSystemRepository : BaseRepository<BPHDbContext, AuditOrganizationManagementSystem>, IAuditOrganizationManagementSystemRepository {
    }

    public interface IAuditOrganizationManagementSystemRepository : IBaseRepository<AuditOrganizationManagementSystem> {

    }
}

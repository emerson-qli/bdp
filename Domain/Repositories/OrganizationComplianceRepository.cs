using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationComplianceRepository : BaseRepository<BPHDbContext, OrganizationCompliance>, IOrganizationComplianceRepository {

    }

    public interface IOrganizationComplianceRepository : IBaseRepository<OrganizationCompliance> {

    }
}

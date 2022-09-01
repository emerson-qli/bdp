using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationPolicyRepository : BaseRepository<BPHDbContext, OrganizationPolicy>, IOrganizationPolicyRepository {
    }

    public interface IOrganizationPolicyRepository : IBaseRepository<OrganizationPolicy> {

    }
}

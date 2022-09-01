using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationContextRepository : BaseRepository<BPHDbContext, OrganizationContext>, IOrganizationContextRepository {

    }

    public interface IOrganizationContextRepository : IBaseRepository<OrganizationContext> {

    }
}

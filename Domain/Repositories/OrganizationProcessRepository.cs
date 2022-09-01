using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationProcessRepository : BaseRepository<BPHDbContext, OrganizationProcess>, IOrganizationProcessRepository {

    }

    public interface IOrganizationProcessRepository : IBaseRepository<OrganizationProcess> {

    }
}

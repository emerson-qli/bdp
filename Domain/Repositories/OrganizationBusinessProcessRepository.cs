using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationBusinessProcessRepository : BaseRepository<BPHDbContext, OrganizationBusinessProcess>, IOrganizationBusinessProcessRepository {

    }

    public interface IOrganizationBusinessProcessRepository : IBaseRepository<OrganizationBusinessProcess> {

    }
}

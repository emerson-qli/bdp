using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationBusinessProcessSubProcessRepository : BaseRepository<BPHDbContext, OrganizationBusinessProcessSubProcess>, IOrganizationBusinessProcessSubProcessRepository {

    }

    public interface IOrganizationBusinessProcessSubProcessRepository : IBaseRepository<OrganizationBusinessProcessSubProcess> {

    }
}

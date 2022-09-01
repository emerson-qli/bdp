using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationContextPESTLERepository : BaseRepository<BPHDbContext, OrganizationContextPESTLE>, IOrganizationContextPESTLERepository {

    }

    public interface IOrganizationContextPESTLERepository : IBaseRepository<OrganizationContextPESTLE> {

    }
}

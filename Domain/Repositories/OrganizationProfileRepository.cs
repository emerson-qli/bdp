using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationProfileRepository : BaseRepository<BPHDbContext, OrganizationProfile>, IOrganizationProfileRepository {

    }

    public interface IOrganizationProfileRepository : IBaseRepository<OrganizationProfile> {

    }
}

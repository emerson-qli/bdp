using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationChartRepository : BaseRepository<BPHDbContext, OrganizationChart>, IOrganizationChartRepository {

    }

    public interface IOrganizationChartRepository : IBaseRepository<OrganizationChart> {

    }
}

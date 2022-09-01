using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationDashboardRepository : BaseRepository<BPHDbContext, OrganizationDashboard>, IOrganizationDashboardRepository {

    }

    public interface IOrganizationDashboardRepository : IBaseRepository<OrganizationDashboard> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationManagementSystemRepository : BaseRepository<BPHDbContext, OrganizationManagementSystem>, IOrganizationManagementSystemRepository {

    }

    public interface IOrganizationManagementSystemRepository : IBaseRepository<OrganizationManagementSystem> {

    }
}

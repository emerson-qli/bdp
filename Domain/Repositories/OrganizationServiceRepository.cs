using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationServiceRepository : BaseRepository<BPHDbContext, OrganizationService>, IOrganizationServiceRepository {

    }

    public interface IOrganizationServiceRepository : IBaseRepository<OrganizationService> {

    }
}

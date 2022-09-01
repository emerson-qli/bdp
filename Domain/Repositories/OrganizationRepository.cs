using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationRepository : BaseRepository<BPHDbContext, Organization>, IOrganizationRepository {

    }

    public interface IOrganizationRepository : IBaseRepository<Organization> {

    }
}

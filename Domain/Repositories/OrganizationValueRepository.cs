using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationValueRepository : BaseRepository<BPHDbContext, OrganizationValue>, IOrganizationValueRepository {

    }

    public interface IOrganizationValueRepository : IBaseRepository<OrganizationValue> {

    }
}

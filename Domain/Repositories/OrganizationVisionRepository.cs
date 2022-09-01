using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationVisionRepository : BaseRepository<BPHDbContext, OrganizationVision>, IOrganizationVisionRepository {

    }

    public interface IOrganizationVisionRepository : IBaseRepository<OrganizationVision> {

    }
}

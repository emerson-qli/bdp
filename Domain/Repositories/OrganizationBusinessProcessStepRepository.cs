using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationBusinessProcessStepRepository : BaseRepository<BPHDbContext, OrganizationBusinessProcessStep>, IOrganizationBusinessProcessStepRepository {

    }

    public interface IOrganizationBusinessProcessStepRepository : IBaseRepository<OrganizationBusinessProcessStep> {

    }
}

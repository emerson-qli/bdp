using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationContextStakeHolderRepository : BaseRepository<BPHDbContext, OrganizationContextStakeHolder>, IOrganizationContextStakeHolderRepository {

    }

    public interface IOrganizationContextStakeHolderRepository : IBaseRepository<OrganizationContextStakeHolder> {

    }
}

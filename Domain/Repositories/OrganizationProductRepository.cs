using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationProductRepository : BaseRepository<BPHDbContext, OrganizationProduct>, IOrganizationProductRepository {

    }

    public interface IOrganizationProductRepository : IBaseRepository<OrganizationProduct> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationContextSWOTRepository : BaseRepository<BPHDbContext, OrganizationContextSWOT>, IOrganizationContextSWOTRepository {

    }

    public interface IOrganizationContextSWOTRepository : IBaseRepository<OrganizationContextSWOT> {

    }
}

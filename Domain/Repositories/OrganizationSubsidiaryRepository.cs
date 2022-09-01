using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationSubsidiaryRepository : BaseRepository<BPHDbContext, OrganizationSubsidiary>, IOrganizationSubsidiaryRepository {

    }

    public interface IOrganizationSubsidiaryRepository : IBaseRepository<OrganizationSubsidiary> {

    }
}

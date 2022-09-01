using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationContextExternalIssueRepository : BaseRepository<BPHDbContext, OrganizationContextExternalIssue>, IOrganizationContextExternalIssueRepository {

    }

    public interface IOrganizationContextExternalIssueRepository : IBaseRepository<OrganizationContextExternalIssue> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationContextInternalIssueRepository : BaseRepository<BPHDbContext, OrganizationContextInternalIssue>, IOrganizationContextInternalIssueRepository {

    }

    public interface IOrganizationContextInternalIssueRepository : IBaseRepository<OrganizationContextInternalIssue> {

    }
}

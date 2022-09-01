using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class IssueTrackerRepository : BaseRepository<BPHDbContext, IssueTracker>, IIssueTrackerRepository {

    }

    public interface IIssueTrackerRepository : IBaseRepository<IssueTracker> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class IssueTypeRepository : BaseRepository<BPHDbContext, IssueType>, IIssueTypeRepository {
    }

    public interface IIssueTypeRepository : IBaseRepository<IssueType> { 
    }
}

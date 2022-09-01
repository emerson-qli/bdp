using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class IssueCategoryRepository : BaseRepository<BPHDbContext, IssueCategory>, IIssueCategoryRepository {

    }

    public interface IIssueCategoryRepository : IBaseRepository<IssueCategory> {

    }
}

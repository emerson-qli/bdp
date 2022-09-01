using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ReviewerRepository : BaseRepository<BPHDbContext, Reviewer>, IReviewerRepository {

    }

    public interface IReviewerRepository : IBaseRepository<Reviewer> {

    }
}

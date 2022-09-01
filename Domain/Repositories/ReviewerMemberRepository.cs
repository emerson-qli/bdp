using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ReviewerMemberRepository : BaseRepository<BPHDbContext, ReviewerMember>, IReviewerMemberRepository {

    }

    public interface IReviewerMemberRepository : IBaseRepository<ReviewerMember> {

    }
}

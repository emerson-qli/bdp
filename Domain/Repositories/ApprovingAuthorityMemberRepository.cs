using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ApprovingAuthorityMemberRepository : BaseRepository<BPHDbContext, ApprovingAuthorityMember>, IApprovingAuthorityMemberRepository {

    }

    public interface IApprovingAuthorityMemberRepository : IBaseRepository<ApprovingAuthorityMember> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ApprovingAuthorityRepository : BaseRepository<BPHDbContext, ApprovingAuthority>, IApprovingAuthorityRepository {

    }

    public interface IApprovingAuthorityRepository : IBaseRepository<ApprovingAuthority> {

    }
}

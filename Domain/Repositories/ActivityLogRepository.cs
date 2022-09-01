using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ActivityLogRepository : BaseRepository<BPHDbContext, ActivityLog>, IActivityLogReposity {
    }

    public interface IActivityLogReposity : IBaseRepository<ActivityLog> {

    }
}

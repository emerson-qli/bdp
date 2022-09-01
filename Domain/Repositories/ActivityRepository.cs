using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ActivityRepository : BaseRepository<BPHDbContext, Activity>, IActivityRepository {

    }

    public interface IActivityRepository : IBaseRepository<Activity> {

    }
}

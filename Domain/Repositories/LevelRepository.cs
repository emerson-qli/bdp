using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class LevelRepository : BaseRepository<BPHDbContext, Level>, ILevelRepository {

    }

    public interface ILevelRepository : IBaseRepository<Level> {

    }
}

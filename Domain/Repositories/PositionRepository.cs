using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class PositionRepository : BaseRepository<BPHDbContext, Position>, IPositionRepository {

    }

    public interface IPositionRepository : IBaseRepository<Position> {

    }
}

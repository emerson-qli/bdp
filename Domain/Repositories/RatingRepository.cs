using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class RatingRepository : BaseRepository<BPHDbContext, Rating>, IRatingRepository {

    }

    public interface IRatingRepository : IBaseRepository<Rating> {

    }
}

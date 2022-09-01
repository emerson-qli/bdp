using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DivisionRepository : BaseRepository<BPHDbContext, Division>, IDivisionRepository {

    }

    public interface IDivisionRepository : IBaseRepository<Division> {

    }
}

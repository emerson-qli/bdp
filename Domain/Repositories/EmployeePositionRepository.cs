using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeePositionRepository : BaseRepository<BPHDbContext, EmployeePosition>, IEmployeePositionRepository {

    }

    public interface IEmployeePositionRepository : IBaseRepository<EmployeePosition> {

    }
}

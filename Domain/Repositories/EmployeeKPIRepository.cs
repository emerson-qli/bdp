using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeKPIRepository : BaseRepository<BPHDbContext, EmployeeKPI>, IEmployeeKPIRepository {

    }

    public interface IEmployeeKPIRepository : IBaseRepository<EmployeeKPI> {

    }
}

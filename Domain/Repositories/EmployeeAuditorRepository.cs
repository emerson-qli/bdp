using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeAuditorRepository : BaseRepository<BPHDbContext, EmployeeAuditor>, IEmployeeAuditorRepository {

    }

    public interface IEmployeeAuditorRepository : IBaseRepository<EmployeeAuditor> {

    }
}

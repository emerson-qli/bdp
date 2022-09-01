using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeProgramRepository : BaseRepository<BPHDbContext, EmployeeProgram>, IEmployeeProgramRepository {

    }

    public interface IEmployeeProgramRepository : IBaseRepository<EmployeeProgram> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeRepository : BaseRepository<BPHDbContext, Employee>, IEmployeeRepository {

    }

    public interface IEmployeeRepository : IBaseRepository<Employee> {

    }
}

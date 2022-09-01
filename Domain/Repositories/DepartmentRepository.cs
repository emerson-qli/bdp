using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DepartmentRepository : BaseRepository<BPHDbContext, Department>, IDepartmentRepository {

    }

    public interface IDepartmentRepository : IBaseRepository<Department> {

    }
}

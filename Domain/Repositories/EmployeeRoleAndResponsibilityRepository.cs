using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeRoleAndResponsibilityRepository : BaseRepository<BPHDbContext, EmployeeRoleAndResponsibility>, IEmployeeRoleAndResponsibilityRepository {

    }

    public interface IEmployeeRoleAndResponsibilityRepository : IBaseRepository<EmployeeRoleAndResponsibility> {

    }
}

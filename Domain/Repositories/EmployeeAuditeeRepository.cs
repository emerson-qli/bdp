using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeAuditeeRepository : BaseRepository<BPHDbContext, EmployeeAuditee>, IEmployeeAuditeeRepository {

    }

    public interface IEmployeeAuditeeRepository : IBaseRepository<EmployeeAuditee> {

    }
}

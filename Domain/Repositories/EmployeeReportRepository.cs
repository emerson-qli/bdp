using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeReportRepository : BaseRepository<BPHDbContext, EmployeeReport>, IEmployeeReportRepository {

    }

    public interface IEmployeeReportRepository : IBaseRepository<EmployeeReport> {

    }
}

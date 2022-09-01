using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeReportRecipientRepository : BaseRepository<BPHDbContext, EmployeeReportRecipient>, IEmployeeReportRecipientRepository {

    }

    public interface IEmployeeReportRecipientRepository : IBaseRepository<EmployeeReportRecipient> {

    }
}

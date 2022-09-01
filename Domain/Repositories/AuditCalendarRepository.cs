using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditCalendarRepository : BaseRepository<BPHDbContext, AuditCalendar>, IAuditCalendarRepository {

    }

    public interface IAuditCalendarRepository : IBaseRepository<AuditCalendar> {

    }
}

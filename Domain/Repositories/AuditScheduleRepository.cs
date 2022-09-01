using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditScheduleRepository : BaseRepository<BPHDbContext, AuditSchedule>, IAuditScheduleRepository {
    }

    public interface IAuditScheduleRepository : IBaseRepository<AuditSchedule> {

    }
}

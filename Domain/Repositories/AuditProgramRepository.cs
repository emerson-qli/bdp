using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditProgramRepository : BaseRepository<BPHDbContext, AuditProgram>, IAuditProgramRepository {
    }

    public interface IAuditProgramRepository : IBaseRepository<AuditProgram> {

    }
}

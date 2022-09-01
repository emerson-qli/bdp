using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditTeamRepository : BaseRepository<BPHDbContext, AuditTeam>, IAuditTeamRepository {

    }

    public interface IAuditTeamRepository : IBaseRepository<AuditTeam> {

    }
}

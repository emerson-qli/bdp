using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditCategoryRepository : BaseRepository<BPHDbContext, AuditCategory>, IAuditCategoryRepository {

    }
    
    public interface IAuditCategoryRepository : IBaseRepository<AuditCategory> {

    }
}

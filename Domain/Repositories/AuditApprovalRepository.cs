using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditApprovalRepository : BaseRepository<BPHDbContext, AuditApproval>, IAuditApprovalRepository{
    }

    public interface IAuditApprovalRepository : IBaseRepository <AuditApproval> { 
    }
}

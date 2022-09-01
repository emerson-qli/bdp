using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AuditPlanSupportingDocumentRepository : BaseRepository<BPHDbContext, AuditPlanSupportingDocument>, IAuditPlanSupportingDocumentRepository {
    }

    public interface IAuditPlanSupportingDocumentRepository : IBaseRepository<AuditPlanSupportingDocument> {

    }
}

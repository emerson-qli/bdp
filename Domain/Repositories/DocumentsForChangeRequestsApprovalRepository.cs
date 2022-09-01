using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentsForChangeRequestsApprovalRepository : BaseRepository<BPHDbContext, DocumentsForChangeRequestsApproval>, IDocumentsForChangeRequestsApprovalRepository {

    }

    public interface IDocumentsForChangeRequestsApprovalRepository : IBaseRepository<DocumentsForChangeRequestsApproval> {

    }
}
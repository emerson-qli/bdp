using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestApprovalRepository : BaseRepository<BPHDbContext, DocumentRequestApproval>, IDocumentRequestApprovalRepository {

    }

    public interface IDocumentRequestApprovalRepository : IBaseRepository<DocumentRequestApproval> {

    }
}

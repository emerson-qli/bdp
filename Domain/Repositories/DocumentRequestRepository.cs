using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestRepository : BaseRepository<BPHDbContext, DocumentRequest>, IDocumentRequestRepository {

    }

    public interface IDocumentRequestRepository : IBaseRepository<DocumentRequest> {

    }
}

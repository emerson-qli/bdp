using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestSupportingDocumentRepository : BaseRepository<BPHDbContext, DocumentRequestSupportingDocument>, IDocumentRequestSupportingDocumentRepository {

    }

    public interface IDocumentRequestSupportingDocumentRepository : IBaseRepository<DocumentRequestSupportingDocument> {

    }
}

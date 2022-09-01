using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestExternalDocumentRepository : BaseRepository<BPHDbContext, DocumentRequestExternalDocument>, IDocumentRequestExternalDocumentRepository {
    }

    public interface IDocumentRequestExternalDocumentRepository : IBaseRepository <DocumentRequestExternalDocument> {

    }
}

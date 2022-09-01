using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentsForChangeRequestsSupportingDocumentRepository : BaseRepository<BPHDbContext, DocumentsForChangeRequestsSupportingDocument>, IDocumentsForChangeRequestsSupportingDocumentRepository {

    }

    public interface IDocumentsForChangeRequestsSupportingDocumentRepository : IBaseRepository<DocumentsForChangeRequestsSupportingDocument> {

    }
}
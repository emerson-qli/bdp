using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentClassificationRepository : BaseRepository<BPHDbContext, DocumentClassification>, IDocumentClassification {
    }

    public interface IDocumentClassification : IBaseRepository<DocumentClassification> {

    }
}

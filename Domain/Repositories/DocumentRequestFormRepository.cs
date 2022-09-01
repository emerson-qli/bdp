using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestFormRepository : BaseRepository<BPHDbContext, DocumentRequestForm>, IDocumentRequestFomRepository {
    
    }

    public interface IDocumentRequestFomRepository : IBaseRepository<DocumentRequestForm> {

    }
}

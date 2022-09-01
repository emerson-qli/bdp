using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentLogRepository : BaseRepository<BPHDbContext, DocumentLog>, IDocumentLogRepository {
    }
    public interface IDocumentLogRepository : IBaseRepository<DocumentLog> {

    }
}

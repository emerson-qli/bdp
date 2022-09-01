using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentsForChangeRequestsRepository : BaseRepository<BPHDbContext, DocumentsForChangeRequests>, IDocumentsForChangeRequestsRepository {

    }

    public interface IDocumentsForChangeRequestsRepository : IBaseRepository<DocumentsForChangeRequests> {

    }
}

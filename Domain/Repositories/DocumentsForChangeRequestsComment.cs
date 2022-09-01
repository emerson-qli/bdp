using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentsForChangeRequestsCommentRepository : BaseRepository<BPHDbContext, DocumentsForChangeRequestsComment>, IDocumentsForChangeRequestsCommentRepository {

    }

    public interface IDocumentsForChangeRequestsCommentRepository : IBaseRepository<DocumentsForChangeRequestsComment> {

    }
}
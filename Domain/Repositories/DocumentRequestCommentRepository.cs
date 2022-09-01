using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestCommentRepository : BaseRepository<BPHDbContext, DocumentRequestComment>, IDocumentRequestCommentRepository {

    }

    public interface IDocumentRequestCommentRepository : IBaseRepository<DocumentRequestComment> {

    }
}

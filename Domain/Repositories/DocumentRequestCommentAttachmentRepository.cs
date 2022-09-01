using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentRequestCommentAttachmentRepository : BaseRepository<BPHDbContext, DocumentRequestCommentAttachment>, IDocumentRequestCommentAttachmentRepository {

    }

    public interface IDocumentRequestCommentAttachmentRepository : IBaseRepository<DocumentRequestCommentAttachment> {

    }
}

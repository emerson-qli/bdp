using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentsForChangeRequestsCommentAttachmentRepository : BaseRepository<BPHDbContext, DocumentsForChangeRequestsCommentAttachment>, IDocumentsForChangeRequestsCommentAttachmentRepository {

    }

    public interface IDocumentsForChangeRequestsCommentAttachmentRepository : IBaseRepository<DocumentsForChangeRequestsCommentAttachment> {

    }
}
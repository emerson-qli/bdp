using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class PublishedDocumentsCommentAttachmentRepository : BaseRepository<BPHDbContext, PublishedDocumentsCommentAttachment>, IPublishedDocumentsCommentAttachmentRepository {

    }

    public interface IPublishedDocumentsCommentAttachmentRepository : IBaseRepository<PublishedDocumentsCommentAttachment> {

    }
}

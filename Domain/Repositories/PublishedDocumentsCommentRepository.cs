using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class PublishedDocumentsCommentRepository : BaseRepository<BPHDbContext, PublishedDocumentsComment>, IPublishedDocumentsCommentRepository {

    }

    public interface IPublishedDocumentsCommentRepository : IBaseRepository<PublishedDocumentsComment> {

    }
}

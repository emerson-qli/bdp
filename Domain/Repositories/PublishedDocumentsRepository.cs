using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class PublishedDocumentsRepository : BaseRepository<BPHDbContext, PublishedDocuments>, IPublishedDocumentsRepository {

    }

    public interface IPublishedDocumentsRepository : IBaseRepository<PublishedDocuments> {

    }
}

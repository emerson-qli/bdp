using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class PublishedDocumentsSupportingDocumentRepository : BaseRepository<BPHDbContext, PublishedDocumentsSupportingDocument>, IPublishedDocumentsSupportingDocumentRepository {

    }

    public interface IPublishedDocumentsSupportingDocumentRepository : IBaseRepository<PublishedDocumentsSupportingDocument> {

    }
}

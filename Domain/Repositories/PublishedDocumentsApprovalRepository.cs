using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class PublishedDocumentsApprovalRepository : BaseRepository<BPHDbContext, PublishedDocumentsApproval>, IPublishedDocumentsApprovalRepository {

    }

    public interface IPublishedDocumentsApprovalRepository : IBaseRepository<PublishedDocumentsApproval> {

    }
}

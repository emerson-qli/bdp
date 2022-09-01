using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentQualificationRepository : BaseRepository<BPHDbContext, DocumentQualification>, IDocumentQualificationRepository {

    }

    public interface IDocumentQualificationRepository : IBaseRepository<DocumentQualification> {

    }
}

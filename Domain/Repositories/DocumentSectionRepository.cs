using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentSectionRepository : BaseRepository<BPHDbContext, DocumentSection>, IDocumentSectionRepository {

    }

    public interface IDocumentSectionRepository : IBaseRepository<DocumentSection> {

    }
}

using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentCategoryRepository : BaseRepository<BPHDbContext, DocumentCategory>, IDocumentCategoryRepository {

    }

    public interface IDocumentCategoryRepository : IBaseRepository<DocumentCategory> {

    }
}

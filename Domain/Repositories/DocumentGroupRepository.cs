using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentGroupRepository : BaseRepository<BPHDbContext, DocumentGroup>, IDocumentGroupRepository {

    }

    public interface IDocumentGroupRepository : IBaseRepository<DocumentGroup> {

    }
}

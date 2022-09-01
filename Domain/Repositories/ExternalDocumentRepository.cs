using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ExternalDocumentRepository : BaseRepository <BPHDbContext, ExternalDocument>, IExternalDocumentRepository {
    }

    public interface IExternalDocumentRepository : IBaseRepository <ExternalDocument> {

    }
}

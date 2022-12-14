using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class DocumentSettingRepository : BaseRepository<BPHDbContext, DocumentSetting>, IDocumentSettingRepository {

    }

    public interface IDocumentSettingRepository : IBaseRepository<DocumentSetting> {

    }
}


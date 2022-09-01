using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeDocumentRepository : BaseRepository<BPHDbContext, EmployeeDocument>, IEmployeeDocumentRepository {

    }

    public interface IEmployeeDocumentRepository : IBaseRepository<EmployeeDocument> {

    }
}

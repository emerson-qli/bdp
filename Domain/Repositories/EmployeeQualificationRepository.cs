using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeQualificationRepository : BaseRepository<BPHDbContext, EmployeeQualification>, IEmployeeQualificationRepository {

    }

    public interface IEmployeeQualificationRepository : IBaseRepository<EmployeeQualification> {

    }
}

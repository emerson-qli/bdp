using Domain.Models;
using Domain.Configurations;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeEducationRepository : BaseRepository<BPHDbContext, EmployeeEducation>, IEmployeeEducationRepository {

    }

    public interface IEmployeeEducationRepository : IBaseRepository<EmployeeEducation> {

    }
}

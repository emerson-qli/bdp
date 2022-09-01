using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeExperienceRepository : BaseRepository<BPHDbContext, EmployeeExperience>, IEmployeeExperienceRepository {

    }

    public interface IEmployeeExperienceRepository : IBaseRepository<EmployeeExperience> {

    }
}

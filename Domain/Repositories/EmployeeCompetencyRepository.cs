using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeCompetencyRepository : BaseRepository<BPHDbContext, EmployeeCompetency>, IEmployeeCompetencyRepository {

    }

    public interface IEmployeeCompetencyRepository : IBaseRepository<EmployeeCompetency> {

    }
}

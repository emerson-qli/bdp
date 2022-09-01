using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeJobDescriptionRepository : BaseRepository<BPHDbContext, EmployeeJobDescription>, IEmployeeJobDescriptionRepository {

    }

    public interface IEmployeeJobDescriptionRepository : IBaseRepository<EmployeeJobDescription> {

    }
}

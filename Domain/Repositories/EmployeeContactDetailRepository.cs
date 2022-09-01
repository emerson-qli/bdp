using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class EmployeeContactDetailRepository : BaseRepository<BPHDbContext, EmployeeContactDetail>, IEmployeeContactDetailRepository {

    }

    public interface IEmployeeContactDetailRepository : IBaseRepository<EmployeeContactDetail> {

    }
}

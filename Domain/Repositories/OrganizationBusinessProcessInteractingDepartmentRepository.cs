using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationBusinessProcessInteractingDepartmentRepository : BaseRepository<BPHDbContext, OrganizationBusinessProcessInteractingDepartment>, IOrganizationBusinessProcessInteractingDepartmentRepository {

    }

    public interface IOrganizationBusinessProcessInteractingDepartmentRepository : IBaseRepository<OrganizationBusinessProcessInteractingDepartment> {

    }
}

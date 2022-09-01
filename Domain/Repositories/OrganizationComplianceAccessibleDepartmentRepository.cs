using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationComplianceAccessibleDepartmentRepository : BaseRepository<BPHDbContext, OrganizationComplianceAccessibleDepartment>, IOrganizationComplianceAccessibleDepartment {
    }

    public interface IOrganizationComplianceAccessibleDepartment : IBaseRepository<OrganizationComplianceAccessibleDepartment> { 
    }
}

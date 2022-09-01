using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationReportRepository : BaseRepository<BPHDbContext, OrganizationReport>, IOrganizationReportRepository {

    }

    public interface IOrganizationReportRepository : IBaseRepository<OrganizationReport> {

    }
}

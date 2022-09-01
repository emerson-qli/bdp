using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class OrganizationComplianceCertificateRepository : BaseRepository<BPHDbContext, OrganizationComplianceCertificate>, IOrganizationComplianceCertificateRepository {

    }

    public interface IOrganizationComplianceCertificateRepository : IBaseRepository<OrganizationComplianceCertificate> {

    }
}

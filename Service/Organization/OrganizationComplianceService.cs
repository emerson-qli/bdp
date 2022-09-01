using Domain.Models;
using Service.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationComplianceService : BaseService<Domain.Models.OrganizationCompliance, Domain.Repositories.OrganizationComplianceRepository> {
        public List<OrganizationCompliance> GetAll(Guid id) {

            var entities = Repository.AllIncluding(a => a.AccessibleDepartments)
                                     .Where(a => a.OrganizationId == id)
                                     .ToList();

            return entities;

        }

        public OrganizationCompliance GetAllIncluding(Guid id) {

            var entities = Repository.AllIncluding(a => a.AccessibleDepartments)
                                     .Where(a => a.Id == id)
                                     .FirstOrDefault();

            return entities;

        }

        public OrganizationCompliance UpdateOrganizationCompliance(OrganizationCompliance organizationCompliance) {
            var data = new OrganizationComplianceAccessibleDepartmentService().GetAllBy(a => a.OrganizationComplianceId == organizationCompliance.Id).ToList();
            var entity = base.Get(organizationCompliance.Id);

            data.ForEach(a => {
                new OrganizationComplianceAccessibleDepartmentService().Delete(a.Id);
            });

            if (entity != null) {
                entity.AccessibleDepartments = organizationCompliance.AccessibleDepartments;
                entity.UpdatedAt = DateTime.Now;
                base.UpdateAndGet(organizationCompliance);
            }

            return entity;
        }
    }
}

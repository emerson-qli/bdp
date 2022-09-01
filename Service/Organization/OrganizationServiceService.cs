using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationServiceService : BaseService<Domain.Models.OrganizationService, Domain.Repositories.OrganizationServiceRepository> {

        public override Domain.Models.OrganizationService SaveAndGet(Domain.Models.OrganizationService entity) {

            var profile = new OrganizationService().GetAll().FirstOrDefault();

            if (profile != null) {
                base.SaveAndGet(entity);
                return entity;
            } else {
                return null;
            }

        }
    }
}

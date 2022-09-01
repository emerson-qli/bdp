using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationSubsidiaryService : BaseService<Domain.Models.OrganizationSubsidiary, Domain.Repositories.OrganizationSubsidiaryRepository> {
        public override Domain.Models.OrganizationSubsidiary SaveAndGet(Domain.Models.OrganizationSubsidiary entity) {

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

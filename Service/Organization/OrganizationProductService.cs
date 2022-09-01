using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationProductService : BaseService<Domain.Models.OrganizationProduct, Domain.Repositories.OrganizationProductRepository> {

        public override Domain.Models.OrganizationProduct SaveAndGet(Domain.Models.OrganizationProduct entity) {

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

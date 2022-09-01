using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationService : BaseService<Domain.Models.Organization, Domain.Repositories.OrganizationRepository> {

        public override Domain.Models.Organization SaveAndGet(Domain.Models.Organization entity) {

            var existingEntity = base.Get(entity.Id);
            if(existingEntity == null) {
                return base.SaveAndGet(entity);
            }else {
                entity.UpdatedAt = DateTime.Now;
                return base.UpdateAndGet(entity);
            }

        }

    }
}

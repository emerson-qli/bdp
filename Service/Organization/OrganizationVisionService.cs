using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationVisionService : BaseService<Domain.Models.OrganizationVision, Domain.Repositories.OrganizationVisionRepository> {

        public override OrganizationVision SaveAndGet(OrganizationVision entity) {

            var existingEntity = base.Get(entity.Id);

            if(existingEntity != null) {
                return base.UpdateAndGet(entity);
            }else {
                return base.SaveAndGet(entity);
            }

        }

    }
}

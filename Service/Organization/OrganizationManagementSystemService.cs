using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationManagementSystemService : BaseService<Domain.Models.OrganizationManagementSystem, Domain.Repositories.OrganizationManagementSystemRepository> {

        public override Domain.Models.OrganizationManagementSystem SaveAndGet(Domain.Models.OrganizationManagementSystem entity) {

            var profile = new OrganizationService().GetAll().FirstOrDefault();

            if (profile != null) {
                base.SaveAndGet(entity);
                return entity;
            } else {
                return null;
            }

        }

        public List<Domain.Models.OrganizationManagementSystem> GetAllManagemenSystem() {

            var profile = new OrganizationService().GetAll().FirstOrDefault();
            var mstype = new List<Domain.Models.OrganizationManagementSystem>();

            if (profile != null) {
                mstype = new OrganizationManagementSystemService().GetAllBy(a => a.OrganizationId == profile.Id).ToList();
            }

            return mstype;
            
        }
    }
}

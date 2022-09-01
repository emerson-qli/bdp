using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationBusinessProcessInteractingDepartmentService : BaseService<Domain.Models.OrganizationBusinessProcessInteractingDepartment, Domain.Repositories.OrganizationBusinessProcessInteractingDepartmentRepository> {

        public override OrganizationBusinessProcessInteractingDepartment SaveAndGet(OrganizationBusinessProcessInteractingDepartment entity) {

            var existingEntity = base.GetAllBy(a => a.DepartmentId == entity.DepartmentId &&
                                                    a.OrganizationBusinessProcessId == entity.OrganizationBusinessProcessId)
                                     .FirstOrDefault();

            if(existingEntity != null) {
                throw new ArgumentException(string.Format("{0} already exists", entity.DepartmentName));
            }else {
                return base.SaveAndGet(entity);
            }

        }

    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Organization {
    public class OrganizationBusinessProcessService : BaseService<Domain.Models.OrganizationBusinessProcess, Domain.Repositories.OrganizationBusinessProcessRepository> {

        public override OrganizationBusinessProcess Get(Guid id) {

            var entity = base.Get(id);

            if(entity != null) {
                entity.SubProcesses                                      = new OrganizationBusinessProcessSubProcessService().GetAllBy(a => a.OrganizationBusinessProcessId == entity.Id).ToList();
                entity.OrganizationBusinessProcessInteractingDepartments = new OrganizationBusinessProcessInteractingDepartmentService().GetAllBy(a => a.OrganizationBusinessProcessId == entity.Id).ToList();
                entity.OrganizationBusinessProcessSteps                  = new OrganizationBusinessProcessStepService().GetAllBy(a => a.OrganizationBusinessProcessId == entity.Id).ToList();
                entity.SubProcesses                                      = new OrganizationBusinessProcessSubProcessService().GetAllBy(a => a.OrganizationBusinessProcessId == entity.Id).ToList();
            }

            return entity;
        }

        public Domain.Models.OrganizationBusinessProcess UpdateOrganizationProcessDepartment(OrganizationBusinessProcess organizationBusinessProcess) {

            var entity = base.Get(organizationBusinessProcess.Id);
            if(entity != null) {
                entity.DepartmentName   = organizationBusinessProcess.DepartmentName;
                entity.DepartmentId     = organizationBusinessProcess.DepartmentId;
                entity.UpdatedAt        = DateTime.Now;
            }

            return base.UpdateAndGet(entity);

        }

        public override OrganizationBusinessProcess UpdateAndGet(OrganizationBusinessProcess entity) {

            var existingEntity = base.Get(entity.Id);
            if(existingEntity != null) {
                existingEntity.Name      = entity.Name;
                existingEntity.UpdatedAt = DateTime.Now;
            }

            return base.UpdateAndGet(existingEntity);
        }
    }
}

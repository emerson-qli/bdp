using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Employee {
    public class EmployeeService : BaseService<Domain.Models.Employee, Domain.Repositories.EmployeeRepository> {

        public override Domain.Models.Employee SaveAndGet(Domain.Models.Employee entity) {
            entity.Fullname = string.Format("{0} {1} {2}", entity.Firstname, entity.Middlename, entity.Lastname);
            return base.SaveAndGet(entity);
        }

        public Domain.Models.Employee GetAllData(Guid userId) {
            var entity = Repository.AllIncluding(a => a.ContactDetails, a => a.Documents, a => a.EmployeePositions, a => a.EmployeeCompetencies, a => a.Experiences, a => a.JobDescriptions, a => a.Programs, a => a.Reports, a => a.EmployeeKPIs, a => a.EmployeeRoleAndResponsibilities, a => a.EmployeeQualifications)
                                   .Where(a => a.UserId == userId)
                                   .FirstOrDefault();
            return entity;
        }

        public override Domain.Models.Employee UpdateAndGet(Domain.Models.Employee entity){
            entity.Fullname = string.Format("{0} {1} {2}", entity.Firstname, entity.Middlename, entity.Lastname);
            return base.UpdateAndGet(entity);
        }


        public List<Domain.Models.Employee> GetIncludingPositions() {

            var entities = Repository.AllIncluding(a => a.EmployeePositions)
                                     .ToList();

            return entities;

        }

        public Domain.Models.Employee UploadFile(Domain.Models.Employee employee) {
            var entity = base.Get(employee.Id);
            if (entity != null) {
                entity.Photo                 = employee.Photo;
                entity.PhotoOriginalFileName = employee.PhotoOriginalFileName;
                base.UpdateAndGet(entity);
            }

            return entity;
        }

        public Domain.Models.Employee GetPhoto(Guid id) {

            var entity = base.GetAllBy(a => a.UserId == id).FirstOrDefault();

            return entity;

        }
    }
}

using Domain.Models;
using Service.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ApprovingAuthority {
    public class ApprovingAuthorityMemberService : BaseService<Domain.Models.ApprovingAuthorityMember, Domain.Repositories.ApprovingAuthorityMemberRepository> {

        public override ApprovingAuthorityMember SaveAndGet(ApprovingAuthorityMember entity) {

            var existingEntity = base.GetAllBy(a => a.EmployeeId == entity.EmployeeId && a.ApprovingAuthorityId == entity.ApprovingAuthorityId).FirstOrDefault();
            if(existingEntity == null) {
                return base.SaveAndGet(entity);
            }else {
                throw new Exception("Employee already exists");
            }
        }

        public override ApprovingAuthorityMember UpdateAndGet(ApprovingAuthorityMember entity) {

            var existingEntity = base.GetAllBy(a => a.EmployeeId == entity.EmployeeId && a.ApprovingAuthorityId == entity.ApprovingAuthorityId && a.Id != entity.Id).FirstOrDefault();
            if (existingEntity == null) {
                return base.UpdateAndGet(entity);
            }
            else {
                throw new Exception("Employee already exists");
            }
        }

        public List<ApprovingAuthorityMember> GetMembers(Guid setId) {

            var members = base.GetAllBy(a => a.ApprovingAuthorityId == setId).ToList();
            return members;

        }

    }
}

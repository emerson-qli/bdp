using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Reviewer {
    public class ReviewerMemberService : BaseService<Domain.Models.ReviewerMember, Domain.Repositories.ReviewerMemberRepository> {

        public override ReviewerMember SaveAndGet(ReviewerMember entity) {

            var existingEntity = base.GetAllBy(a => a.EmployeeId == entity.EmployeeId && a.ReviewerId == entity.ReviewerId).FirstOrDefault();
            if (existingEntity == null) {
                return base.SaveAndGet(entity);
            }
            else {
                throw new Exception("Employee already exists");
            }
        }

        public override ReviewerMember UpdateAndGet(ReviewerMember entity) {

            var existingEntity = base.GetAllBy(a => a.EmployeeId == entity.EmployeeId && a.ReviewerId == entity.ReviewerId && a.Id != entity.Id).FirstOrDefault();
            if (existingEntity == null) {
                return base.SaveAndGet(entity);
            }
            else {
                throw new Exception("Employee already exists");
            }
        }

    }
}

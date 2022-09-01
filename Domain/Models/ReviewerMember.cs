using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {


    public class ReviewerMember : BaseModel<ReviewerMemberState> {

        public Guid ReviewerId {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

        public string EmployeePosition {
            get;
            set;
        }

    }

    public enum ReviewerMemberState {
        Active,
        Inactive
    }

}

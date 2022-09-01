using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class ApprovingAuthorityMember : BaseModel<ApprovingAuthorityMemberState> {

        public Guid ApprovingAuthorityId {
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

    public enum ApprovingAuthorityMemberState {
        Active,
        Inactive
    }
}

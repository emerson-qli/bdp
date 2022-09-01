using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationContextStakeHolder : BaseModel<OrganizationContextStakeHolderState> {

        public Guid OrganizationContextId {
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

        public string Description {
            get;
            set;
        }

    }

    public enum OrganizationContextStakeHolderState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeRoleAndResponsibility : BaseModel<EmployeeRoleAndResponsibilityState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string OriginalFileName {
            get;
            set;
        }
        public string UniqueFileName {
            get;
            set;
        }

    }

    public enum EmployeeRoleAndResponsibilityState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeAuditor : BaseModel<EmployeeAuditorState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeFullname {
            get;
            set;
        }

        public Guid EmployeeAuditorId {
            get;
            set;
        }

        public string EmployeeAuditorFullname {
            get;
            set;
        }

    }

    public enum EmployeeAuditorState {
        Active,
        Inactive
    }
}

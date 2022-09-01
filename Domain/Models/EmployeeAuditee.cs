using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeAuditee : BaseModel<EmployeeAuditeeState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeFullname {
            get;
            set;
        }

        public Guid EmployeeAuditeeId {
            get;
            set;
        }

        public string EmployeeAuditeeFullname {
            get;
            set;
        }

    }

    public enum EmployeeAuditeeState {
        Active,
        Inactive
    }
}

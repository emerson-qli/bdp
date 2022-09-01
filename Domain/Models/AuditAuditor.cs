using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditAuditor : BaseModel<AuditAuditorState> {
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

        public Guid DepartmentId {
            get;
            set;
        }

        public string DepartmentName {
            get;
            set;
        }
    }

    public enum AuditAuditorState {
        Active,
        Inactive
    }
}

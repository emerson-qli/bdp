using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditPlanAuditor : BaseModel<AuditPlanAuditorState> {
        public Guid AuditPlanId {
            get;
            set;
        }

        public Guid AuditorId {
            get;
            set;
        }

        public string AuditorName {
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

    public enum AuditPlanAuditorState {
        Active,
        Inactive
    }
}

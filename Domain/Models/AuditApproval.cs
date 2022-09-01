using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditApproval : BaseModel<AuditApprovalState> {
        public Guid AuditPlanId {
            get;
            set;
        }
        public string AuditName {
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
    }

    public enum AuditApprovalState {
        Initiated,
        ForApproval,
        Approved
    }
}

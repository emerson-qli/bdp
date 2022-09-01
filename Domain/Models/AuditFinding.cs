using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditFinding : BaseModel<AuditFindingState> {
        public Guid AuditPlanId {
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
    }

    public enum AuditFindingState {
        Active,
        Inactive
    }
}

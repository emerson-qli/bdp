using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditSchedule : BaseModel<AuditScheduleState> {

        public Guid AuditPlanId {
            get;
            set;
        }

        public string AuditPlanName {
            get;
            set;
        }
        
        public DateTime StartDate {
            get;
            set;
        }

        public DateTime EndDate {
            get;
            set;
        }


    }

    public enum AuditScheduleState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class Audit : BaseModel<InternalAuditState> {

        public string ReferenceNumber {
            get;
            set;
        }

        public Guid AuditProgramId {
            get;
            set;
        }

        public Guid AuditCategoryId {
            get;
            set;
        }

        public string AuditCategoryName {
            get;
            set;
        }

        public List<AuditOrganizationManagementSystem> ManagementSystems {
            get;
            set;
        }

        public List<AuditOrganizationBusinessProcess> BusinessProcesses {
            get;
            set;
        }

        public DateTime? StartDate {
            get;
            set;
        }
        
        public DateTime? EndDate {
            get;
            set;
        }

        public int TotalPreplan {
            get;
            set;
        }

        public int Planned {
            get;
            set;
        }

        public int Scheduled {
            get;
            set;
        }

        public int HasToPlan {
            get;
            set;
        }

        public int Audited {
            get;
            set;
        }

        public int TotalFindings {
            get;
            set;
        }

        public int Closed {
            get;
            set;
        }

        public int Open {
            get;
            set;
        }

        public List<AuditPlan> AuditPlans {
            get;
            set;
        }

        public AuditType Type {
            get;
            set;
        }

    }

    public enum AuditType {
        Internal,
        External
    }

    public enum InternalAuditState {
        Active,
        Inactive
    }
}

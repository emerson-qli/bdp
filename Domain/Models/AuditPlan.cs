using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class AuditPlan : BaseModel<AuditPlanState> {

        public Guid AuditId {
            get;
            set;
        }

        public string AuditCategoryName {
            get;
            set;
        }

        public string AuditCategoryId {
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

        public DateTime? StartDatePlan {
            get;
            set;
        }

        public DateTime? EndDatePlan {
            get;
            set;
        }

        public string Criteria {
            get;
            set;
        }

        public string Objective {
            get;
            set;
        }

        public Guid AuthorId {
            get;
            set;
        }

        public string AuthorName {
            get;
            set;
        }

        public List<AuditPlanSupportingDocument> AuditPlanSupportingDocuments {
            get;
            set;
        } 

        public List<AuditSchedule> AuditSchedules {
            get;
            set;
        }

        public List<AuditPlanAuditor> AuditPlanAuditors {
            get;
            set;
        }

        public List<AuditFinding> AuditFindings {
            get;
            set;
        }
    }

    public enum AuditPlanState {
        Initiated,
        InProgress,
        Audited
    }
}

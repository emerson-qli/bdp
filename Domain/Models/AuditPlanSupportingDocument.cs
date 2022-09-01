using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditPlanSupportingDocument : BaseModel<AuditPlanSupportingDocumentState> {
        public Guid AuditPlanId {
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

    public enum AuditPlanSupportingDocumentState { 
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class DocumentsForChangeRequestsApproval : BaseModel<PublishedDocumentsForChangeRequestsApprovalState> {
        public Guid DocumentRequestId {
            get;
            set;
        }

        public string DocumentRequestName {
            get;
            set;
        }

        public Guid ApprovingAuthorityId {
            get;
            set;
        }

        public string ApprovingAuthoryName {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

        public string EmployeePosition {
            get;
            set;
        }
    }
    public enum PublishedDocumentsForChangeRequestsApprovalState {
        Initiated,
        ForApproval,
        Approved
    }
}

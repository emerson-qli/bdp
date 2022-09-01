using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class DocumentLog : BaseModel<DocumentLogState> {
        public Guid DocumentRequestId {
            get;
            set;
        }
        public string DocumentRequestName {
            get;
            set;
        }

        public string DocumentRequestDescription {
            get;
            set;
        }

        public Guid UserId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }
    }

    public enum DocumentLogState {
        Active,
        Inactive
    }
}

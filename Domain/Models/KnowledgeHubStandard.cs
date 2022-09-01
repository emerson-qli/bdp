using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class KnowledgeHubStandard : BaseModel<KnowledgeHubStandardState> {
        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public Guid ManagementSystemId {
            get;
            set;
        }

        public string ManagementSystemName {
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

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
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

    public enum KnowledgeHubStandardState {
        Active,
        Inactive
    }
}

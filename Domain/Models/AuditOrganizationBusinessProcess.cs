using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditOrganizationBusinessProcess : BaseModel<AuditOrganizationBusinessProcessState> {

        public Guid AuditId {
            get;
            set;
        }

        public Guid? OrganizationBusinessProcessId {
            get;
            set;
        }

        public string OrganizationBusinessProcessName {
            get;
            set;
        }

    }

    public enum AuditOrganizationBusinessProcessState {
        Active,
        Inactive
    }
}

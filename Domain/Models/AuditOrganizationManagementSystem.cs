using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditOrganizationManagementSystem : BaseModel<AuditOrganizationManagementSystemState> {

        public Guid AuditId {
            get;
            set;
        }

        public Guid OrganizationManagementSystemId {
            get;
            set;
        }

        public string OrganizationManagementSystemType {
            get;
            set;
        }

    }

    public enum AuditOrganizationManagementSystemState {
        Active,
        Inactive
    }
}

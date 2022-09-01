using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationComplianceAccessibleDepartment : BaseModel<OrganizationComplianceAccessibleDepartmentState> {
        public Guid OrganizationComplianceId {
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
    }

    public enum OrganizationComplianceAccessibleDepartmentState {
        Active,
        Inactive
    }
}

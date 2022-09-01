using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {


    public class OrganizationBusinessProcessInteractingDepartment : BaseModel<OrganizationBusinessProcessInteractingDepartmentState> {


        public Guid OrganizationBusinessProcessId {
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

    public enum OrganizationBusinessProcessInteractingDepartmentState {
        Active,
        Inactive
    }

}

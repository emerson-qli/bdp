using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationBusinessProcess : BaseModel<OrganizationBusinessProcessState> {

        public Guid OrganizationId {
            get;
            set;
        }

        public Guid? OrganizationBusinessProcessId {
            get;
            set;
        }

        public string Name {
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

        public List<OrganizationBusinessProcessStep> OrganizationBusinessProcessSteps {
            get;
            set;
        }

        public List<OrganizationBusinessProcessInteractingDepartment> OrganizationBusinessProcessInteractingDepartments {
            get;
            set;
        }

        public List<OrganizationBusinessProcessSubProcess> SubProcesses {
            get;
            set;
        }

    }

    public enum OrganizationBusinessProcessState {
        Active,
        Inactive
    }
}

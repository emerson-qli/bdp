using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationBusinessProcessSubProcess : BaseModel<OrganizationBusinessProcessSubProcessState> {


        public Guid OrganizationBusinessProcessId {
            get;
            set;
        }


        public string OrganizationBusinessProcessSubProcessName {
            get;
            set;
        }

        public Guid OrganizationBusinessProcessSubProcessId {
            get;
            set;
        }

    }

    public enum OrganizationBusinessProcessSubProcessState {
        Active,
        Inactive
    }
}

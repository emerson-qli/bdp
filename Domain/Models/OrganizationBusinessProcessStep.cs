using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationBusinessProcessStep : BaseModel<OrganizationBusinessProcessStepState> {

        public Guid OrganizationBusinessProcessId {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

    }

    public enum OrganizationBusinessProcessStepState {
        Active,
        Inactive
    }
}

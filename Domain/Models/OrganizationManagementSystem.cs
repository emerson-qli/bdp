using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationManagementSystem : BaseModel<OrganizationManagementSystemState> {

        public Guid OrganizationId {
            get;
            set;
        }

        public string Type {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string Version {
            get;
            set;
        }

    }

    public enum OrganizationManagementSystemState {
        Active,
        Inactive
    }
}

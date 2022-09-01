using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationValue : BaseModel<OrganizationValueState> {

        public Guid OrganizationVisionId {
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

    public enum OrganizationValueState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationVision : BaseModel<OrganizationVisionState> {

        public Guid OrganizationId {
            get;
            set;
        }

        public string Vision {
            get;
            set;
        }

        public string Mission {
            get;
            set;
        }

        public List<OrganizationValue> OrganizationValues {
            get;
            set;
        }


    }

    public enum OrganizationVisionState {
        Active,
        Inactive
    }
}

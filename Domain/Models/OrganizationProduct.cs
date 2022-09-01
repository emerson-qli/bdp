using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationProduct : BaseModel<OrganizationProductState> {

        public Guid OrganizationId {
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

    public enum OrganizationProductState {
        Active,
        Inactive
    }
}

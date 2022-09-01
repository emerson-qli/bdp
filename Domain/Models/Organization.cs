using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class Organization : BaseModel<OrganizationState> {


        public string Name {
            get;
            set;
        }

        public string LogoFileName {
            get;
            set;
        }

        public string LogoUniqueFileName {
            get;
            set;
        }

        public string CompanyDetails {
            get;
            set;
        }

        public DateTime Established {
            get;
            set;
        }

        public string Address {
            get;
            set;
        }

        public string ProfileDocumentFileName {
            get;
            set;
        }

        public string ProfileDocumentUniqueFileName {
            get;
            set;
        }

        public string Code {
            get;
            set;
        }

    }

    public enum OrganizationState {
        Active,
        Inactive
    }
}

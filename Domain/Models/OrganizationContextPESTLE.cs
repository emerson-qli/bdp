using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationContextPESTLE : BaseModel<OrganizationContextPESTLEState> {

        public Guid OrganizationId {
            get;
            set;
        }

        public Guid RatingId {
            get;
            set;
        }

        public string RatingName {
            get;
            set;
        }

        public string RatingColor {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

    }

    public enum OrganizationContextPESTLEState {
        General,
        Political,
        Economical,
        Social,
        Technological,
        Legal,
        Ecological
    }
}

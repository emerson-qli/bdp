using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeExperience : BaseModel<EmployeeExperienceState> {

        public string EmployeeFullName {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string PositionName {
            get;
            set;
        }

        public int StartYear {
            get;
            set;
        }

        public int EndYear {
            get;
            set;
        }

        public string CompanyName {
            get;
            set;
        }

        public string CompanyLocation {
            get;
            set;
        }



    }

    public enum EmployeeExperienceState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class EmployeeEducation : BaseModel<EmployeeEducationState> {
        public Guid EmployeeId {
            get;
            set;
        }

        public string School {
            get;
            set;
        }

        public string Course {
            get;
            set;
        }

        public int YearGraduated {
            get;
            set;
        }
    }

    public enum EmployeeEducationState {
        Active,
        Inactive
    }
}

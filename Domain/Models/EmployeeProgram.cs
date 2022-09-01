using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeProgram : BaseModel<EmployeeProgramState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public DateTime ExpectedStartDate {
            get;
            set;
        }

        public DateTime ExpectedEndDate {
            get;
            set;
        }

        public DateTime? ActualStartDate {
            get;
            set;
        }

        public DateTime? ActualEndDate {
            get;
            set;
        }

    }

    public enum EmployeeProgramState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class EmployeePosition : BaseModel<EmployeePositionState> {

        public string EmployeeFullName {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public Guid DepartmentId {
            get;
            set;
        }

        public string DepartmentName {
            get;
            set;
        }

        public Guid PositionId {
            get;
            set;
        }

        public string PositionName {
            get;
            set;
        }

        public DateTime StartDate {
            get;
            set;
        }

        public DateTime? EndDate {
            get;
            set;
        }

        public Guid? ReportingTo {
            get;
            set;
        }

        public string ReportingToEmployeeFullName {
            get;
            set;
        }

    }

    public enum EmployeePositionState {
        Active,
        Inactive
    }
}

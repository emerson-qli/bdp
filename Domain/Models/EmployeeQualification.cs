using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeQualification : BaseModel<EmployeeQualificationState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string Label {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

    }

    public enum EmployeeQualificationState {
        Qualification,
        Certification
    }
}

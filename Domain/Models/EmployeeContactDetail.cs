using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeContactDetail : BaseModel<EmployeeContactDetailState> {

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

        public string Label {
            get;
            set;
        }

        public string Contact {
            get;
            set;
        }

    }

    public enum EmployeeContactDetailState {
        Regular,
        Emergency
    }
}

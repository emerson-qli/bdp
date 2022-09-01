using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeKPI : BaseModel<EmployeeKPIState> {

        public Guid EmployeeId {
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

        public decimal Target {
            get;
            set;
        }

    }

    public enum EmployeeKPIState {
        Active,
        Inactive
    }
}

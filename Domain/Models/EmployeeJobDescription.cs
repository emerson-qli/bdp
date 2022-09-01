using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeJobDescription : BaseModel<EmployeeJobDescriptionState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string Title {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public Guid SupervisorId {
            get;
            set;
        }

        public string SupervisorName {
            get;
            set;
        }

    }

    public enum EmployeeJobDescriptionState {
        Active,
        Inactive
    }
}

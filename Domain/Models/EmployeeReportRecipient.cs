using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeReportRecipient : BaseModel<EmployeeReportRecipientState> {

        public Guid EmployeeReportId {
            get;
            set;
        }

        public Guid SubmittedToId {
            get;
            set;
        }

        public string SubmittedToFullName {
            get;
            set;
        }

    }

    public enum EmployeeReportRecipientState {
        Active,
        Inactive
    }
}

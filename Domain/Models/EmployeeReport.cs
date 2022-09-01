using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeReport : BaseModel<EmployeeReportState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public ReportFrequency Frequency {
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

        public string FilePath {
            get;
            set;
        }

        public string OriginalFileName {
            get;
            set;
        }

        public string UniqueFileName {
            get;
            set;
        }

        public List<EmployeeReportRecipient> Recipients {
            get;
            set;
        }

    }

    public enum ReportFrequency {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum EmployeeReportState {
        Active,
        Inactive
    }
}

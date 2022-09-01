using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class ExternalDocument : BaseModel<ExternalDocumentState> {

        public string Name {
            get;
            set;
        }

        public string Title {
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

        public DateTime Date {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string ReceivedBy {
            get;
            set;
        }

        public string From {
            get;
            set;
        }

        public string Remarks {
            get;
            set;
        }
    }

    public enum ExternalDocumentState {
        Active,
        Inactive
    }
}

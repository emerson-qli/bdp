using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeDocument : BaseModel<EmployeeDocumentState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public Guid DocumentGroupId {
            get;
            set;
        }

        public string DocumentGroupName {
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

        public string Path {
            get;
            set;
        }

        public string FileName {
            get;
            set;
        }

        public string OriginalFileName {
            get;
            set;
        }

    }

    public enum EmployeeDocumentState {
        Active,
        Inactive
    }
}

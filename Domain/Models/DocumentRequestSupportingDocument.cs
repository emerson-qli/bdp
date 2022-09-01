using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class DocumentRequestSupportingDocument : BaseModel<DocumentRequestSupportingDocumentState> {

        public Guid DocumentRequestId {
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

    }

    public enum DocumentRequestSupportingDocumentState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class DocumentRequestExternalDocument : BaseModel<DocumentRequestExternalDocumentState> {
        public Guid DocumentRequestId {
            get;
            set;
        }

        public string ExternalDocumentOriginalFileName {
            get;
            set;
        }

        public string ExternalDocumentUniqueFileName {
            get;
            set;
        }
    }

    public enum DocumentRequestExternalDocumentState {
        Active,
        Inactive
    }
}

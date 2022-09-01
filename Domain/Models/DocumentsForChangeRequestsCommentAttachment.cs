using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class DocumentsForChangeRequestsCommentAttachment : BaseModel<DocumentsForChangeRequestsCommentAttachmentState> {
        public Guid DocumentRequestCommentId {
            get;
            set;
        }

        public string OrginalFileName {
            get;
            set;
        }

        public string UniqueFileName {
            get;
            set;
        }
    }
    public enum DocumentsForChangeRequestsCommentAttachmentState {
        Active,
        Inactive
    }
}

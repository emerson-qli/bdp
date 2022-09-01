using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class DocumentRequestCommentAttachment : BaseModel<DocumentRequestCommentAttachmentState> {

        public Guid DocumentRequestId {
            get;
            set;
        }

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

    public enum DocumentRequestCommentAttachmentState {
        Active,
        Inactive
    }
}

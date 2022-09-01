using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class PublishedDocumentsCommentAttachment : BaseModel<PublishedDocumentsCommentAttachmentState> {
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

    public enum PublishedDocumentsCommentAttachmentState {
        Active,
        Inactive
    }
}

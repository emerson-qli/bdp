using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class PublishedDocumentsComment : BaseModel<PublishedDocumentsCommentState> {
        public Guid DocumentRequestId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string Comment {
            get;
            set;
        }

        public List<DocumentRequestCommentAttachment> Attachments {
            get;
            set;
        }
    }

    public enum PublishedDocumentsCommentState {
        Active,
        Inactive
    }
}

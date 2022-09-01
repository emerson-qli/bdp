using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class Notification : BaseModel<NotificationState> {

        public string Description {
            get;
            set;
        }

        public string Link {
            get;
            set;
        }

        public NotificationType Type {
            get;
            set;
        }

        public Guid UserId {
            get;
            set;
        }

        public string UserFullName {
            get;
            set;
        }
    }

    public enum NotificationType {
        DocumentRequestForReview,
        DocumentRequestForApproval,
        DocumentRequestForPublish,
        DocumentRequestForRevision,
        DocumentRequestReviewed,
        DocumentRequestApproved,
        DocumentRequestPublished,
        DocumentRequestRevised,
        AuditPlanForApproval,
        ExpiringDocument
    }

    public enum NotificationState {
        New,
        Read
    }
}

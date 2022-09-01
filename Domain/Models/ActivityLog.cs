using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class ActivityLog : BaseModel<ActivityLogState> {
        public Guid UserId {
            get;
            set;
        }

        public string Username {
            get;
            set;
        }

        public string PageUrl {
            get;
            set;
        }

        public string PageName {
            get;
            set;
        }

        public PageAction PageAction {
            get;
            set;
        }
    }

    public enum PageAction {
        View,
        Save,
        Delete,
        Update,
        Submit,
        Approve,
        Reject
    }

    public enum ActivityLogState {
        Active,
        Inactive
    }
}

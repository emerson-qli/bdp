using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class SettingEmployeeNotificationRecipient : BaseModel<SettingEmployeeNotificationRecipientState> {
        public Guid SettingId {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }
    }

    public enum SettingEmployeeNotificationRecipientState { 
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class AuditCalendar : BaseModel<AuditCalendarState> {



    }

    public enum AuditCalendarState {
        Active,
        Inactive
    }
}

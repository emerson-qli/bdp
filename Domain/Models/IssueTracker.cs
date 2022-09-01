using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class IssueTracker : BaseModel<IssueTrackerState> {



    }

    public enum IssueTrackerState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class ActionPlan : BaseModel<ActionPlanState> {



    }

    public enum ActionPlanState {
        Active,
        Inactive
    }
}

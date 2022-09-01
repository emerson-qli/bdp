using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class AuditTeam : BaseModel<AuditTeamsState> {



    }

    public enum AuditTeamsState {
        Active,
        Inactive
    }
}

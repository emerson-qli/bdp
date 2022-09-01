using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class AuditUniverse : BaseModel<AuditUniverseState> {



    }

    public enum AuditUniverseState {
        Active,
        Inactive
    }
}

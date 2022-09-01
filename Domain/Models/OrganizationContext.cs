using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationContext : BaseModel<OrganizationContextState> {



    }

    public enum OrganizationContextState {
        Active,
        Inactive
    }
}

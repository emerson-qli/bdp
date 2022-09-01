using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class PositionResponsibilities : BaseModel<PositionResponsibilitiesState> {

        public Guid PositionId {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

    }

    public enum PositionResponsibilitiesState {
        Active,
        Inactive
    }
}

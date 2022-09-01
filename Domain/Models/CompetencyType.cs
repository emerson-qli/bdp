using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class CompetencyType : BaseModel<CompetencyTypeState> {

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

    }

    public enum CompetencyTypeState {
        Active,
        Inactive
    }
}

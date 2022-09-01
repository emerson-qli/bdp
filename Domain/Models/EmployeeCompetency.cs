using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class EmployeeCompetency : BaseModel<EmployeeCompetenciesState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string Provider {
            get;
            set;
        }

        public DateTime TrainingStartDate {
            get;
            set;
        }

        public DateTime TrainingEndDate {
            get;
            set;
        }

        public decimal Proficiency {
            get;
            set;
        }

        public decimal UserProficiency {
            get;
            set;
        }

        public Guid CompetencyTypeId {
            get;
            set;
        }

        public string CompetencyTypeName {
            get;
            set;
        }

    }

    public enum EmployeeCompetenciesState {
        Active,
        Inactive
    }
}

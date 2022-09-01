using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Department : BaseModel<DepartmentState> {

        public string Name {
            get;
            set;
        }

        public string ProcessCode {
            get;
            set;
        }

        public string Code {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public Guid LevelId {
            get;
            set;
        }

        public string LevelName {
            get;
            set;
        }

        public Guid DivisionId {
            get;
            set;
        }

        public string DivisionName {
            get;
            set;
        }

        public Guid? HeadId {
            get;
            set;
        }

        public string HeadName {
            get;
            set;
        }

    }

    public enum DepartmentState {
        Active,
        Inactive
    }
}

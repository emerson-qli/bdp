using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class AuditProgram : BaseModel <AuditProgramState>{

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public Guid AuditCategoryId {
            get;
            set;
        }

        public List<Audit> Audits {
            get;
            set;
        }
    
    }

    public enum AuditProgramState {
        Inactive,
        Active
    }
}

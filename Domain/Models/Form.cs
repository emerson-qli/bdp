using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Form : BaseModel<FormState> {

        public string Name {
            get;
            set;
        }

        public Guid UserId {
            get;
            set;
        }

        public string AuthorName {
            get;
            set;
        }

        public List<FormGroup> Groups {
            get;
            set;
        }

    }

    public enum FormState {
        Active,
        Inactive
    }
}

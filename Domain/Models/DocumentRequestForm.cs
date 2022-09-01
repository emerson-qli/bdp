using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class DocumentRequestForm : BaseModel<DocumentRequestFormState> {

        public Guid FormId {
            get;
            set;
        }

        public Guid DocumentRequestId {
            get;
            set;
        }
    }

    public enum DocumentRequestFormState {
        Active,
        Inactive
    }
}

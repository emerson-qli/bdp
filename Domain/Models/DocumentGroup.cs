using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class DocumentGroup : BaseModel<DocumentGroupState> {

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string DocumentTypePrefix {
            get;
            set;
        }

        public Guid DocumentCategoryId {
            get;
            set;
        }

        public string DocumentCategoryName {
            get;
            set;
        }

    }

    public enum DocumentGroupState {
        Active,
        Inactive
    }
}

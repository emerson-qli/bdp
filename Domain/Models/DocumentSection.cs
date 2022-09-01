using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class DocumentSection : BaseModel<DocumentSectionState> {

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }
    }

    public enum DocumentSectionState {
        Active,
        Inactive
    }
}

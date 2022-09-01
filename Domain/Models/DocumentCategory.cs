using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class DocumentCategory : BaseModel<DocumentCategoryState> {

        public string Name {
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

    }

    public enum DocumentCategoryState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class DocumentSetting : BaseModel<DocumentSettingState> {
        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }
    }

    public enum DocumentSettingState {
        Active,
        Inactive
    }
}

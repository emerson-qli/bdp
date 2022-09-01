using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class FormGroup : BaseModel<FormGroupState> {

        public Guid FormId {
            get;
            set;
        }

        public string FormName {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public List<FormGroupQuestion> Questions {
            get;
            set;
        }

        public GroupingType Type {
            get;
            set;
        }

    }

    public enum GroupingType {
        Plain,
        Table,
        OrderedList,
        UnorderedList
    }

    public enum FormGroupState {
        Active,
        Inactive
    }
}

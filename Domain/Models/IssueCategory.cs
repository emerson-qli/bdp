using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class IssueCategory : BaseModel<IssueCategoryState> {

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public Type Type {
            get;
            set;
        }


    }

    public enum Type {
        Internal,
        External
    }

    public enum IssueCategoryState {
        Active,
        Inactive
    }
}

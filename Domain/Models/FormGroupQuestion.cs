using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class FormGroupQuestion : BaseModel<FormGroupElementState> {

        public string Question {
            get;
            set;
        }

        public Required Required {
            get;
            set;
        }

        public List<FormGroupQuestionOption> Options {
            get;
            set;
        }

        public decimal Percentage {
            get;
            set;
        }
    }

    public enum Required {
        Required,
        NotRequired
    }


    public enum FormGroupElementState {
        Active,
        Inactive
    }

}

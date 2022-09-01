using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class FormGroupQuestionOption : BaseModel<FormGroupQuestionOptionState> {

        public Guid FormGroupQuestionID {
            get;
            set;
        }

        public string Option {
            get;
            set;
        }

        public OptionType Type {
            get;
            set;
        }

        public decimal Point {
            get;
            set;
        }

        public decimal Percentage {
            get;
            set;
        }
    }


    public enum OptionType {
        Textbox,
        RadioButton,
        TextArea,
        CheckBox,
        Dropdown,
        Choices
    }

    public enum FormGroupQuestionOptionState {
        Active,
        Inactive
    }
}

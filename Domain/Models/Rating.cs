using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class Rating : BaseModel<RatingState> {

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string Color {
            get;
            set;
        }

    }

    public enum RatingState {
        Active,
        Inactive
    }
}

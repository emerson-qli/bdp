using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class Level : BaseModel<LevelState> {

        public string Name {
            get;
            set;
        }


    }

    public enum LevelState {
        Active,
        Inactive
    }
}

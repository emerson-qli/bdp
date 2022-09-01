using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Country : BaseModel<CountryState> {

        public string Name {
            get;
            set;
        }

        public List<CountryStateRegion> CountryStateRegions {
            get;
            set;
        }

    }

    public enum CountryState {
        Active,
        Inactive
    }
}

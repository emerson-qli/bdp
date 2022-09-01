using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class City : BaseModel<CityState> {

        public Guid CountryStateRegionId {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

    }

    public enum CityState {
        Active,
        Inactive
    }
}

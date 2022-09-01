using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class CountryStateRegion : BaseModel<CountryStateRegionType> {


        public Guid CountryId {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public List<City> Cities {
            get;
            set;
        }

    }

    public enum CountryStateRegionType {
        State,
        Region
    }
}

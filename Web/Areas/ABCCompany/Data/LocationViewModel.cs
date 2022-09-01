using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.ABCCompany.Data {
    public class LocationViewModel {

        public Domain.Models.Country Country {
            get;
            set;
        }
        public Domain.Models.CountryStateRegion CountryStateRegion {
            get;
            set;
        }
        public Domain.Models.City City {
            get;
            set;
        }

        public List<Domain.Models.Country> Countries {
            get;
            set;
        }
        public List<Domain.Models.CountryStateRegion> CountryStateRegions {
            get;
            set;
        }
        public List<Domain.Models.City> Cities {
            get;
            set;
        }

        public Domain.Models.User User {
            get;
            set;
        }

    }
}
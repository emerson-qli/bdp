using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO {
    public class FilterDTO {


        public List<string> CityNames {
            get;
            set;
        }
        public List<string> CountryNames {
            get;
            set;
        }
        public List<string> CountryStateRegionNames {
            get;
            set;
        }

        public DateTime? StartDate {
            get;
            set;
        }

        public DateTime? EndDate {
            get;
            set;
        }

    }
}

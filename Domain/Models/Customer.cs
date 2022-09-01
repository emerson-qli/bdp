using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Customer : BaseModel<CustomerState> {

        public string FirstName {
            get;
            set;
        }

        public string LastName {
            get;
            set;
        }

        public Guid CountryId {
            get;
            set;
        }

        public Guid RegionStateId {
            get;
            set;
        }

        public Guid CityId {
            get;
            set;
        }

        public string CountryName {
            get;
            set;
        }

        public string RegionStateName {
            get;
            set;
        }

        public string CityName {
            get;
            set;
        }

    }

    public enum CustomerState {
        Active,
        Inactive
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Sale : BaseModel<SaleState> {

        public string CustomerFullName {
            get;
            set;
        }

        public string CustomerFirstName {
            get;
            set;
        }

        public string CustomerLastName {
            get;
            set;
        }

        public string CustomerCountryName {
            get;
            set;
        }

        public string CustomerRegionStateName {
            get;
            set;
        }

        public string CustomerCityName {
            get;
            set;
        }

        public Guid CustomerId {
            get;
            set;
        }

        public Guid ProductId {
            get;
            set;
        }

        public string ProductName {
            get;
            set;
        }

        public int Quantity {
            get;
            set;
        }

    }

    public enum SaleState {
        Active,
        Inactive
    }
}

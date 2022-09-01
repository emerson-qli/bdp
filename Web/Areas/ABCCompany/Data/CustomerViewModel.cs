using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.ABCCompany.Data {
    public class CustomerViewModel {

        public Domain.Models.Customer Customer {
            get;
            set;
        }

        public List<Domain.Models.Customer> Customers {
            get;
            set;
        }


        public Domain.Models.User User {
            get;
            set;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.ABCCompany.Data {
    public class SaleViewModel {


        public Domain.Models.User User {
            get;
            set;
        }

        public Domain.Models.Sale Sale {
            get;
            set;
        }

        public List<Domain.Models.Sale> Sales {
            get;
            set;
        }

        public Domain.DTO.FilterDTO Filter {
            get;
            set;
        }

    }
}
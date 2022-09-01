using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Product : BaseModel<ProductState> {

        public string Name {
            get;
            set;
        }

    }

    public enum ProductState {
        Active,
        Inactive
    }
}

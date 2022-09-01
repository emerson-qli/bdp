using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ABCCompany {
    public class CountryStateRegionService : BaseService<Domain.Models.CountryStateRegion, Domain.Repositories.CountryStateRegionRepository> {
        public Domain.Models.CountryStateRegion GetIncludingChild(Guid id) {

            var entity = Repository.AllIncluding(a => a.Cities)
                                   .Where(a => a.Id == id)
                                   .FirstOrDefault();
            return entity;

        }
    }
}

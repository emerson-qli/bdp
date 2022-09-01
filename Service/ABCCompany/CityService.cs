using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ABCCompany {
    public class CityService : BaseService<Domain.Models.City, Domain.Repositories.CityRepository> {
        public Domain.Models.City GetIncludingChild(Guid id) {

            var entity = Repository.All()
                                   .Where(a => a.Id == id)
                                   .FirstOrDefault();

            return entity;
        }
    }
}

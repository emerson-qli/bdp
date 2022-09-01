using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ABCCompany {
    public class CountryService : BaseService<Domain.Models.Country, Domain.Repositories.CountryRepository> {

        public override Domain.Models.Country SaveAndGet(Domain.Models.Country entity) {

            var existing = base.GetAllBy(a => a.Name == entity.Name).FirstOrDefault();

            if(existing != null) {
                throw new Exception(string.Format("{0} already exists", existing.Name));
            }

            return base.SaveAndGet(entity);
        }

        public Domain.Models.Country GetIncludingChild(Guid id) {

            var entity = Repository.AllIncluding(a => a.CountryStateRegions)
                                   .Where(a => a.Id == id)
                                   .FirstOrDefault();
            return entity;

        }
    }
}

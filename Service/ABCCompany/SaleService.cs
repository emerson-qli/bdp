using Domain.DTO;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ABCCompany {
    public class SaleService : BaseService<Domain.Models.Sale, Domain.Repositories.SaleRepository> {
        public List<Domain.Models.Sale> GetAllByFilter(FilterDTO filter) {

            var entities = base.GetAll().ToList();

            if (filter.CityNames != null) {
                entities = entities.Where(a => filter.CityNames.Contains(a.CustomerCityName)).ToList();
            }
            if (filter.CountryNames != null) {
                entities = entities.Where(a => filter.CountryNames.Contains(a.CustomerCountryName)).ToList();
            }
            if (filter.CountryStateRegionNames != null) {
                entities = entities.Where(a => filter.CountryStateRegionNames.Contains(a.CustomerRegionStateName)).ToList();
            }
            if (filter.StartDate.HasValue && filter.EndDate.HasValue) {
                entities = entities.Where(a => a.CreatedAt >= filter.StartDate &&
                                               a.CreatedAt <= filter.EndDate).ToList();
            }

            return entities;

        }
    }
}

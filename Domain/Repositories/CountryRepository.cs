using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories {
    public class CountryRepository : BaseRepository<BPHDbContext, Country>, ICountryRepository {

    }

    public interface ICountryRepository : IBaseRepository<Country> {

    }
}

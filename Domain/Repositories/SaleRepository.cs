using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories {
    public class SaleRepository : BaseRepository<BPHDbContext, Sale>, ISaleRepository {

    }

    public interface ISaleRepository : IBaseRepository<Sale> {

    }
}

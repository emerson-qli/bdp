using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class BusinessRiskTypeRepository : BaseRepository<BPHDbContext, BusinessRiskType>, IBusinessRiskTypeRepository {
    }

    public interface IBusinessRiskTypeRepository : IBaseRepository<BusinessRiskType> { 
    }
}

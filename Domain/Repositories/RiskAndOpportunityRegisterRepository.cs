using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class RiskAndOpportunityRegisterRepository : BaseRepository<BPHDbContext, RiskAndOpportunityRegister>, IRiskAndOpportunityRegisterRepository {

    }

    public interface IRiskAndOpportunityRegisterRepository : IBaseRepository<RiskAndOpportunityRegister> {

    }
}

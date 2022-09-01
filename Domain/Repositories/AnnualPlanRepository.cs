using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class AnnualPlanRepository : BaseRepository<BPHDbContext, AnnualPlan>, IAnnualPlanRepository {

    }

    public interface IAnnualPlanRepository : IBaseRepository<AnnualPlan> {

    }
}

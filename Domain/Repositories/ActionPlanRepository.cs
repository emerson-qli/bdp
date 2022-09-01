using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ActionPlanRepository : BaseRepository<BPHDbContext, ActionPlan>, IActionPlanRepository {

    }

    public interface IActionPlanRepository : IBaseRepository<ActionPlan> {

    }
}

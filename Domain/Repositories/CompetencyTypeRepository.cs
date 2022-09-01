using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class CompetencyTypeRepository : BaseRepository<BPHDbContext, CompetencyType>, ICompetencyTypeRepository {

    }

    public interface ICompetencyTypeRepository : IBaseRepository<CompetencyType> {

    }
}

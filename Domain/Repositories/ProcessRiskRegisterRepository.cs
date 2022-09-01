using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ProcessRiskRegisterRepository : BaseRepository<BPHDbContext, ProcessRiskRegister>, IProcessRiskRegisterRepository {

    }

    public interface IProcessRiskRegisterRepository : IBaseRepository<ProcessRiskRegister> {

    }
}

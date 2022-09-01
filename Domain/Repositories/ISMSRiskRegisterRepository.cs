using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class ISMSRiskRegisterRepository : BaseRepository<BPHDbContext, ISMSRiskRegister>, IISMSRiskRegisterRepository {

    }

    public interface IISMSRiskRegisterRepository : IBaseRepository<ISMSRiskRegister> {

    }
}

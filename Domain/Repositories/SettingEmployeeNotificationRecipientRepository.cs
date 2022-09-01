using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class SettingEmployeeNotificationRecipientRepository : BaseRepository<BPHDbContext, SettingEmployeeNotificationRecipient>, ISettingEmployeeNotificationRecipientRepository {
    }

    public interface ISettingEmployeeNotificationRecipientRepository : IBaseRepository <SettingEmployeeNotificationRecipient> { }
}

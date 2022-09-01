using Domain.Configurations;
using Domain.Models;
using ERC.Framework.Repository;

namespace Domain.Repositories {
    public class NotificationRepository : BaseRepository<BPHDbContext, Notification>, INotificationRepository {

    }

    public interface INotificationRepository : IBaseRepository<Notification> {

    }
}

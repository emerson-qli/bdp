using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Setting {
    public class SettingService : BaseService<Domain.Models.Setting, SettingRepository> {

        public override Domain.Models.Setting UpdateAndGet (Domain.Models.Setting entity) {
            var currentRecipients = new SettingEmployeeNotificationRecipientService().GetAllBy(a => a.SettingId == entity.Id).ToList();

            if (entity != null) {
                entity.Group = "Setting";

                if (entity.EmployeeRecipients != null) {

                    if (currentRecipients.Count != 0) {
                        new SettingEmployeeNotificationRecipientService().Delete(entity.Id);
                    }

                    var recipients = entity.EmployeeRecipients;
                    var newRecipients = new List<Domain.Models.SettingEmployeeNotificationRecipient>();
                    foreach (var recipient in recipients) {
                        newRecipients.Add(new Domain.Models.SettingEmployeeNotificationRecipient {
                            SettingId = entity.Id,
                            EmployeeId = recipient.EmployeeId,
                            EmployeeName = recipient.EmployeeName
                        });
                    }

                    new SettingEmployeeNotificationRecipientService().Save(newRecipients);

                }

            }

            return base.UpdateAndGet(entity);
        }

        public List<Domain.Models.Setting> GetAllIncludingRecipients(Guid id) {

            var entity = Repository.AllIncluding(a => a.EmployeeRecipients).Where(a => a.Id == id).ToList();

            return entity;
        }
    }
}

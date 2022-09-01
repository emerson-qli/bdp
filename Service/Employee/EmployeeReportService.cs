using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Employee {
    public class EmployeeReportService : BaseService<Domain.Models.EmployeeReport, Domain.Repositories.EmployeeReportRepository> {

        public override EmployeeReport SaveAndGet(EmployeeReport entity) {

            var recipients = new List<Domain.Models.EmployeeReportRecipient>();

            entity.Recipients.ForEach(a => {
                recipients.Add(new EmployeeReportRecipient {
                     SubmittedToFullName = new EmployeeService().Get(a.SubmittedToId).Fullname,
                     SubmittedToId       = a.SubmittedToId
                });
            });
            entity.Recipients = recipients;
            return base.SaveAndGet(entity);
        }

        public override EmployeeReport UpdateAndGet(EmployeeReport entity) {
            
            if (entity != null) {
                var recipients = new List<Domain.Models.EmployeeReportRecipient>();
                var data       = new EmployeeReportRecipientService().GetAllBy(a => a.EmployeeReportId == entity.Id).ToList();

                if(data.Count != 0) {
                    for (int i = 0; i < data.Count; i++) {
                        new EmployeeReportRecipientService().Delete(data[i].Id);
                    }
                }

                entity.Recipients.ForEach(a => {
                    recipients.Add(new EmployeeReportRecipient {
                        EmployeeReportId    = entity.Id,
                        SubmittedToFullName = new EmployeeService().Get(a.SubmittedToId).Fullname,
                        SubmittedToId       = a.SubmittedToId
                    });
                });
                entity.Recipients = recipients;

                new EmployeeReportRecipientService().Save(entity.Recipients);
            }

            return base.UpdateAndGet(entity);
        }

        public List<EmployeeReport> GetAllIncludingRecipients(Guid id) {

            var entities = Repository.AllIncluding(a => a.Recipients)
                                     .Where(a => a.EmployeeId == id)
                                     .ToList();

            return entities;

        }

        public EmployeeReport GetIncluding(Guid id) {

            var entity = Repository.AllIncluding(a => a.Recipients)
                                   .Where(a => a.Id == id)
                                   .FirstOrDefault();

            return entity;

        }
    }
}

using Domain.Enums;
using Domain.Repositories;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoleTemplate {
    public class RoleTemplateService : BaseService<RoleTemplateRepository> {
        public bool CheckIfRoleIsAllowed(Guid roleId, Domain.Enums.ApplicationElement element) {
            return Repository().All().Any(a => a.RoleId == roleId && a.ApplicationElement == element); ;
        }

        public Dictionary<string, Domain.Models.RoleTemplate> GetRoleTemplate(Guid id) {
            var permission = Repository().All().Where(a => a.RoleId == id);

            var template = new Dictionary<string, Domain.Models.RoleTemplate>();
            foreach(var item in System.Enum.GetNames(typeof(ApplicationElement))){
                if(item != ApplicationElement.ElementUnknown.ToString())
                    template.Add(item, permission.Where(b => b.ApplicationElement.ToString() == item).FirstOrDefault());
            }

            return template;
        }

        public void Save(Domain.Models.RoleTemplate RoleTemplate) {
            if (RoleTemplate == null)
                throw new ArgumentNullException("RoleTemplate");

            Repository().Add(RoleTemplate);
            Repository().Save();
        }

        public void Delete(Guid roleTemplateId) {
            Repository().Delete(roleTemplateId);
            Repository().Save();
        }

        public void SavePermissions(List<Domain.Models.RoleTemplate> RoleTemplates) {
            if (RoleTemplates == null)
                throw new ArgumentNullException("RoleTemplates");

            Repository().Add(RoleTemplates);
            Repository().Save();
        }

        public void RemovePermissions(Guid id) {
            if (id == null)
                throw new ArgumentNullException("RoleTemplates");

            Repository().Delete(id);
            Repository().Save();
        }
    }
}

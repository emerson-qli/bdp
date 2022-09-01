using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Level {
    public class LevelService : BaseService<Domain.Models.Level, Domain.Repositories.LevelRepository> {
        public List<Domain.Models.Level> GetCurrentAndBelowLevel(Guid id) {

            var currentLevel = base.Get(id);
            var levels = new List<Domain.Models.Level>();

            if (currentLevel != null) {
                levels = base.GetAllBy(a => a.Order <= currentLevel.Order).ToList();
            }

            return levels;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.KnowledgeHub.Data {
    public class KnowledgeHubViewModel : BaseViewModel {

        public Domain.Models.KnowledgeHubStandard KnowledgeHubStandard {
            get;
            set;
        }

        public List<Domain.Models.KnowledgeHubStandard> KnowledgeHubStandards {
            get;
            set;
        }
    }
}

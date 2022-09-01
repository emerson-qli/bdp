using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Document {
    public class DocumentRequestCommentService : BaseService<Domain.Models.DocumentRequestComment, Domain.Repositories.DocumentRequestCommentRepository> {
        public List<DocumentRequestComment> GetAllComments(Guid id) {

            var entities = Repository.AllIncluding(a => a.Attachments)
                                     .Where(a => a.DocumentRequestId == id)
                                     .ToList();

            return entities;

        }

        
    }
}

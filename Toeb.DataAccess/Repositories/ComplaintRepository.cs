using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.GenericRepository;
using Toeb.Model.ViewModels;

namespace Toeb.DataAccess.Repositories
{
    public interface IComplaintRepository : IRepository<Complaint>
    {
        bool NameExist(ComplaintModel model);
    }
    public class ComplaintRepository: Repository<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(ToebEntities context): base(context)
        {

        }

        public bool NameExist(ComplaintModel model)
        {
            return GetAll()
                .Any(c => c.Id != model.Id && model.Title.Equals(c.Title, StringComparison.OrdinalIgnoreCase));
        }
    }
}

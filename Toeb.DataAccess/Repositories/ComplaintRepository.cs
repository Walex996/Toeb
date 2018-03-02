using Library.Repository.Pattern.EntityFramework;
using Library.Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.Model.ViewModels;
using Library.Repository.Pattern.DataContext;
using Library.Repository.Pattern.UnitOfWork;

namespace Toeb.DataAccess.Repositories
{
    public interface IComplaintRepository : IRepository<Complaint>
    {
        bool NameExist(ComplaintModel model);
    }
    public class ComplaintRepository: Repository<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }

        public bool NameExist(ComplaintModel model)
        {
            return Table.Any(c => c.Id != model.Id && model.Title.Equals(c.Title, StringComparison.OrdinalIgnoreCase));
        }
    }
}

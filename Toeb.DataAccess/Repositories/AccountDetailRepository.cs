using Library.Repository.Pattern.DataContext;
using Library.Repository.Pattern.EntityFramework;
using Library.Repository.Pattern.Repositories;
using Library.Repository.Pattern.UnitOfWork;
using Toeb.DataAccess.EF;
using Toeb.Model.ViewModels;

namespace Toeb.DataAccess.Repositories
{
    public interface IAccountDetailRepository : IRepository<AccountDetail>
    {
        bool NameExist(AccountDetailModel model);
    }
    public class AccountDetailRepository : Repository<AccountDetail>, IAccountDetailRepository 
    {
        public AccountDetailRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }

        public bool NameExist(AccountDetailModel model)
        {
            //return GetAll().Any(c => c.Id != model.Id && model.Name.Equals(c.Name,StringComparison.OrdinalIgnoreCase));
            return false;
        }
    }
}

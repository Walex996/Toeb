using Toeb.DataAccess.EF;
using Toeb.DataAccess.GenericRepository;
using Toeb.Model.ViewModels;

namespace Toeb.DataAccess.Repositories
{
    public interface IAccountDetailRepository : IRepository<AccountDetail>
    {
        bool NameExist(AccountDetailModel model);
    }
    public class AccountDetailRepository : Repository<AccountDetail>, IAccountDetailRepository 
    {
        public AccountDetailRepository(ToebEntities context) : base(context)
        {
            
        }

        public bool NameExist(AccountDetailModel model)
        {
            //return GetAll().Any(c => c.Id != model.Id && model.Name.Equals(c.Name,StringComparison.OrdinalIgnoreCase));
            return false;
        }
    }
}

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
    public interface IUserRepository : IRepository<User>
    {
        bool NameExist(UserModel model);
    }
    public class UserRepository:Repository<User>, IUserRepository
    {
        public UserRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }

        public bool NameExist(UserModel model)
        {
            return Table.Any(c => c.Id != model.Id && (model.EmailAddress.Equals(c.EmailAddress, StringComparison.OrdinalIgnoreCase))||(model.PhoneNumber.Equals(c.PhoneNumber, StringComparison.OrdinalIgnoreCase)));
        }
    }
     
}

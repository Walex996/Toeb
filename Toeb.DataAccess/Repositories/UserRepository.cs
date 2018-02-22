using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.GenericRepository;

namespace Toeb.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository:Repository<User>, IUserRepository
    {
        public UserRepository(ToebEntities context):base(context)
        {

        }
    }
     
}

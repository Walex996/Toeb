﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.GenericRepository;
using Toeb.Model.ViewModels;

namespace Toeb.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool NameExist(UserModel model);
    }
    public class UserRepository:Repository<User>, IUserRepository
    {
        public UserRepository(ToebEntities context):base(context)
        {

        }

        public bool NameExist(UserModel model)
        {
            return GetAll().Any(c => c.Id != model.Id && (model.EmailAddress.Equals(c.EmailAddress, StringComparison.OrdinalIgnoreCase))||(model.PhoneNumber.Equals(c.PhoneNumber, StringComparison.OrdinalIgnoreCase)));
        }
    }
     
}

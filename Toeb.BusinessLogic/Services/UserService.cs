using System;
using System.Collections.Generic;
using AutoMapper;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;
using Toeb.Model.ViewModels;

namespace Toeb.BusinessLogic.Services
{
    public interface IUserService
    {
        void Create(UserModel model);
        void Delete(int id);
        void Update(UserModel model);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserItem GetDetails(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public void Create(UserModel model)
        {
            try
            {
                if (model.Password != model.ConfirmPassword)
                    throw new Exception("Passwords do not match");
                if(_userRepository.NameExist(model))
                    throw new Exception("User already exist");
                var user = Mapper.Map<UserModel, User>(model);
                _userRepository.Insert(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var user = _userRepository.Find(id);
                if (user == null)
                    throw new Exception("User not found");
                _userRepository.Delete(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            try
            {
                var entities = _userRepository.GetAll();
                return Mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(entities);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public UserModel GetById(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
                throw new Exception("User not found");
            return Mapper.Map<User, UserModel>(user);
        }

        public UserItem GetDetails(int id)
        {
            try
            {
                var user = _userRepository.Find(id);
                if (user == null)
                    throw new Exception("User not found");
                var item = Mapper.Map<User, UserItem>(user);
                item.Name = user.FirstName + " " + user.LastName;
                item.BuildingCount = user.Buildings.Count;
                item.EstateCount = user.Estates.Count;
                item.ComplaintCount = user.Complaints.Count;
                item.EventCount = user.Events.Count;
                item.ServiceChargeCount = user.ServiceCharges.Count;
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}

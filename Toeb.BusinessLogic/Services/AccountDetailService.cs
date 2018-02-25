//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Toeb.DataAccess.EF;
//using Toeb.DataAccess.Repositories;
//using Toeb.Model.ViewModels;

//namespace Toeb.BusinessLogic.Services
//{
//    public interface IAccountDetailService
//    {
//        void Create(AccountDetailModel model);
//        void Delete(int id);
//        void Update(AccountDetailModel model);
//        IEnumerable<AccountDetailItem> GetAll();
//        AccountDetailModel GetById(int id);
//        AccountDetailItem GetDetails(int id);
//    }
//    public class AccountDetailService : IAccountDetailService
//    {
//        private readonly IAccountDetailRepository _accountDetailRepository;

//        public AccountDetailService(IAccountDetailRepository accountDetailRepository)
//        {
//            _accountDetailRepository = accountDetailRepository;
//        }
//        public void Create(AccountDetailModel model)
//        {
//            try
//            {
//                if (_accountDetailRepository.NameExist(model))
//                    throw new Exception("Account already exists!");
//                var accountDetail = new AccountDetail()
//                {
//                   // Name = model.Name,
//                    //Type = model.Type,
//                   // Number = model.Number,
//                    //BankName = model.BankName
//                };
//                _accountDetailRepository.Insert(accountDetail);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        public void Delete(int id)
//        {
//            try
//            {
//                var accountDetail = _accountDetailRepository.Find(id);
//                if(accountDetail == null)
//                    throw new Exception("Account not found");
//                _accountDetailRepository.Delete(accountDetail);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public void Update(AccountDetailModel model)
//        {
//            try
//            {
//                if (_accountDetailRepository.NameExist(model))
//                    throw new Exception("Account already exists!");
//                var accountDetail = _accountDetailRepository.Find(model.Id);
//                if (accountDetail == null)
//                    throw new Exception("Account not found");
                 

//                _accountDetailRepository.Update(accountDetail);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public IEnumerable<AccountDetailItem> GetAll()
//        {
//            return _accountDetailRepository.GetAll().Select(c => new AccountDetailItem()
//            {
//                //Id = c.Id,
//                //Name = c.Name,
//                //Type = c.Type,
//                //Number = c.Number,
//                //BankName = c.BankName
//            });
//        }

//        public AccountDetailModel GetById(int id)
//        {
//            try
//            {
//                var accountDetail = _accountDetailRepository.Find(id);
//                if (accountDetail == null)
//                    throw new Exception("Account not found!");
//                var item = GetItem(accountDetail);
//                return item;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        private static AccountDetailModel GetItem(AccountDetail accountDetail)
//        {
//            return new AccountDetailItem()
//            {
//                Id = accountDetail.Id,
//                Name = accountDetail.Name,
//                Type = accountDetail.Type,
//                BankName = accountDetail.BankName
//            };
//        }

//        public AccountDetailItem GetDetails(int id)
//        {
//            try
//            {
//                var accountDetail = _accountDetailRepository.Find(id);
//                if (accountDetail == null)
//                    throw new Exception("Account not found");
//                var item = (AccountDetailItem) GetItem(accountDetail);
//                return item;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//    }
//}

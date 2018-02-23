using System;
using System.Collections.Generic;
using System.Linq;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;
using Toeb.Model.ViewModels;

namespace Toeb.BusinessLogic.Services
{
    public interface IServiceChargeService
    {
        void Create(ServiceChargeModel model);
        void Delete(int id);
        void Update(ServiceChargeModel model);
        IEnumerable<ServiceChargeItem> GetAll();
        ServiceChargeModel GetById(int id);
        ServiceChargeItem GetDetails(int id);
    }
    public class ServiceChargeService : IServiceChargeService
    {
        private readonly IServiceChargeRepository _serviceChargeRepository;

        public ServiceChargeService(IServiceChargeRepository serviceChargeRepository)
        {
            _serviceChargeRepository = serviceChargeRepository;
        }

        public void Create(ServiceChargeModel model)
        {
            try
            {
                if (_serviceChargeRepository.NameExist(model)) 
                    throw new ArgumentException("Service CHarge Already Exists!");

               
                var serviceCharge = new ServiceCharge()
                {
                    Name = model.Name,
                    Amount = model.Amount,
                    IsCompulsory = model.IsCompulsory,
                    TotalAmountPaid = 0,
                    DateCreated = model.DateCreated,
                    DueDay = model.DueDay,
                    DueMonth = model.DueMonth
                };
                if (model.BuildingModelIds.Any())
                {
                    serviceCharge.BuildingIds = string.Join(",", model.BuildingModelIds);
                }
                _serviceChargeRepository.Insert(serviceCharge);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var serviceCharge = _serviceChargeRepository.Find(id);
                if (serviceCharge == null)
                    throw new Exception("Service Charge not found!");

                _serviceChargeRepository.Delete(serviceCharge);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ServiceChargeItem> GetAll()
        {
            return _serviceChargeRepository.GetAll().Select(c => new ServiceChargeItem()
            {
                Id = c.Id,
                Name = c.Name,
                DueDay = c.DueDay,
                DueMonth = c.DueMonth,
                Amount = c.Amount,
                DateCreated = c.DateCreated,
                IsCompulsory = c.IsCompulsory,
                TotalAmountPaid = c.TotalAmountPaid,
                BuildingCount = !string.IsNullOrEmpty(c.BuildingIds)?c.BuildingIds.Split(',').ToList().ConvertAll(Convert.ToInt32).Count:0,
                AccountNumber = c.AccountDetail.AccountNumber,
                AccountType = c.AccountDetail.AccountType,
                AccountName = c.AccountDetail.AccountName,
                BankName = c.AccountDetail.BankName
            });
        }

        public ServiceChargeModel GetById(int id)
        {
            try
            {
                var serviceCharge = _serviceChargeRepository.Find(id);
                if (serviceCharge == null)
                    throw new Exception("Service Charge not found!");
                var item= GetItem(serviceCharge);
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static ServiceChargeModel GetItem(ServiceCharge serviceCharge)
        {
            return new ServiceChargeItem()
            {
                Id = serviceCharge.Id,
                Name = serviceCharge.Name,
                Amount = serviceCharge.Amount,
                IsCompulsory = serviceCharge.IsCompulsory,
                TotalAmountPaid = serviceCharge.TotalAmountPaid,
                DateCreated = serviceCharge.DateCreated,
                DueDay = serviceCharge.DueDay,
                DueMonth = serviceCharge.DueMonth
            };
        }

        public ServiceChargeItem GetDetails(int id)
        {
            try
            {
                var serviceCharge = _serviceChargeRepository.Find(id);
                if (serviceCharge == null)
                    throw new Exception("Service Charge not found!");

                var item = (ServiceChargeItem)GetItem(serviceCharge);

                item.AccountNumber = serviceCharge.AccountDetail.AccountNumber;
                item.AccountName = serviceCharge.AccountDetail.AccountName;
                item.AccountType = serviceCharge.AccountDetail.AccountType;
                item.BankName = serviceCharge.AccountDetail.BankName;
                item.BuildingCount = !string.IsNullOrEmpty(serviceCharge.BuildingIds)
                    ? serviceCharge.BuildingIds.Split(',').ToList().ConvertAll(Convert.ToInt32).Count
                    : 0;
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(ServiceChargeModel model)
        {
            try
            {
                if (_serviceChargeRepository.NameExist(model))
                    throw new Exception("Service Charge Already Exists");
                var serviceCharge = _serviceChargeRepository.Find(model.Id);
                if (serviceCharge == null)
                    throw new Exception("Service Charge not found");
                serviceCharge.Name = model.Name;
                serviceCharge.Amount = model.Amount;
                serviceCharge.DateCreated = model.DateCreated;
                serviceCharge.IsCompulsory = model.IsCompulsory;
                serviceCharge.DueDay = model.DueDay;
                serviceCharge.DueMonth = model.DueMonth;

                _serviceChargeRepository.Update(serviceCharge);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

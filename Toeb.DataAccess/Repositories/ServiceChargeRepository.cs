using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Toeb.DataAccess.EF;
using Toeb.Model.ViewModels;

namespace Toeb.DataAccess.Repositories
{
    public interface IServiceChargeRepository
    {
        IEnumerable<ServiceChargeModel> GetServiceCharges();
        ServiceCharge GetServiceCharge(int id);
        ServiceCharge CreateServiceCharge(ServiceChargeModel model);
        void DeleteServiceCharge(int id);
        void UpdateServiceCharge(int id, ServiceChargeModel model);
    }
    public class ServiceChargeRepository : IServiceChargeRepository
    {
        ToebEntities _toebEntities = new ToebEntities();
        public IEnumerable<ServiceChargeModel> GetServiceCharges()
        {
            try
            {
                var serviceCharges = new List<ServiceChargeModel>();
                foreach (var serviceCharge in _toebEntities.ServiceCharges.ToList())
                {
                    serviceCharges.Add(new ServiceChargeModel()
                    {
                        Id = serviceCharge.Id,
                        Name = serviceCharge.Name,
                        Amount = serviceCharge.Amount,
                        DueMonth = serviceCharge.DueMonth,
                        DueDay = serviceCharge.DueDay,
                        TotalAmountPaid = serviceCharge.TotalAmountPaid,
                        IsCompulsory = serviceCharge.IsCompulsory
                    });
                }

                return serviceCharges;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ServiceCharge GetServiceCharge(int id)
        {
            try
            {
                return _toebEntities.ServiceCharges.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ServiceCharge CreateServiceCharge(ServiceChargeModel model)
        {
            try
            {
                var serviceCharge = new ServiceCharge
                {
                    Name = model.Name,
                    Amount = model.Amount,
                    DateCreated = model.DateCreated,
                    DueDay = model.DueDay,
                    DueMonth = model.DueMonth,

                };
                _toebEntities.ServiceCharges.Add(serviceCharge);
                _toebEntities.Entry(serviceCharge).State = EntityState.Added;
                _toebEntities.SaveChanges();
                return serviceCharge;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteServiceCharge(int id)
        {
            try
            {
                var serviceCharge = _toebEntities.ServiceCharges;
                if (serviceCharge.Find(id) != null)
                {
                    serviceCharge.Remove(serviceCharge.Find(id));
                    _toebEntities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateServiceCharge(int id, ServiceChargeModel model)
        {
            try
            {
                var serviceCharge = _toebEntities.ServiceCharges.Find(id);
                if (serviceCharge == null) throw new Exception("State Not Found");
                
                _toebEntities.Entry(serviceCharge).State = EntityState.Modified;
                _toebEntities.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

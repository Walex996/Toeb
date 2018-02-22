using System;
using System.Data.Entity;
using System.Linq;
using Toeb.DataAccess.EF;

namespace Toeb.DataAccess.Repositories
{
    public interface IServiceChargeRepository
    {
        IQueryable<ServiceCharge> GetServiceCharges();
        ServiceCharge GetServiceCharge(int id);
        ServiceCharge CreateServiceCharge(ServiceCharge serviceCharge);
        void DeleteServiceCharge(int id);
        void UpdateServiceCharge(int id, ServiceCharge serviceCharge);
    }
    public class ServiceChargeRepository : IServiceChargeRepository
    {
        private ToebEntities _toebEntities;
        public IQueryable<ServiceCharge> GetServiceCharges()
        {
            try
            {
                return _toebEntities.ServiceCharges;
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

        public ServiceCharge CreateServiceCharge(ServiceCharge serviceCharge)
        {
            try
            {
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

        public void UpdateServiceCharge(int id, ServiceCharge serviceCharge)
        {
            try
            {
                if (_toebEntities.ServiceCharges.Find(id) != null)
                {
                    _toebEntities.Entry(serviceCharge).State = EntityState.Modified;
                    _toebEntities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

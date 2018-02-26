using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.GenericRepository;
using Toeb.Model.ViewModels;

namespace Toeb.DataAccess.Repositories
{
    public interface IServiceChargeRepository : IRepository<ServiceCharge>
    {
        bool NameExist(ServiceChargeModel model);
    }
    public class ServiceChargeRepository : Repository<ServiceCharge>, IServiceChargeRepository
    {
        public ServiceChargeRepository(ToebEntities context) : base(context)
        {
            
        }

        public bool NameExist(ServiceChargeModel model)
        {
            return GetAll().Any(c => c.Id != model.Id && model.Name.Equals(c.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

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
    public interface IEstateRepository : IRepository<Estate>
    {
        bool NameExist(EstateModel model);
    }
    public class EstateRepository: Repository<Estate>, IEstateRepository
    {
        public EstateRepository(ToebEntities context):base(context)
        {
        }

        public bool NameExist(EstateModel model)
        {
            return GetAll().Any(c => c.Id != model.Id && model.Name.Equals(c.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

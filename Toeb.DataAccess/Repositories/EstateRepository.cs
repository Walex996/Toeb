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
    public interface IEstateRepository : IRepository<Estate>
    {
        bool NameExist(EstateModel model);
    }
    public class EstateRepository: Repository<Estate>, IEstateRepository
    {
        public EstateRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }

        public bool NameExist(EstateModel model)
        {
            return Table.Any(c => c.Id != model.Id && model.Name.Equals(c.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

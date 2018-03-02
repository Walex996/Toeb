using Library.Repository.Pattern.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.Model.ViewModels;
using Library.Repository.Pattern.DataContext;
using Library.Repository.Pattern.UnitOfWork;
using Library.Repository.Pattern.Repositories;

namespace Toeb.DataAccess.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        bool NameExist(EventModel model);
    }
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork)
        {
        }

        public bool NameExist(EventModel model)
        {
            return Table.Any(c => c.Id != model.Id && model.Name.Equals(c.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

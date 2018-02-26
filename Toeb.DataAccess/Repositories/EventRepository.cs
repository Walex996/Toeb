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
    public interface IEventRepository : IRepository<Event>
    {
        bool NameExist(EventModel model);
    }
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ToebEntities context) :base(context)
        {

        }
        
        public bool NameExist(EventModel model)
        {
            return GetAll().Any(c => c.Id != model.Id && model.Name.Equals(c.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

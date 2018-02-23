using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.Model.ViewModels;
using System.Data.Entity;
using Toeb.DataAccess.GenericRepository;

namespace Toeb.DataAccess.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
        bool NameExist(StateModel model);
    }
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(ToebEntities context):base(context)
        {

        }

        public bool NameExist(StateModel model)
        {
             return GetAll().Any(c => c.Id != model.Id && model.Name.Equals(c.Name,StringComparison.OrdinalIgnoreCase));
        }
    }
    //public interface IStateRepository
    //{
    //    void Insert(StateModel model);
    //    void Update(StateModel model);
    //    void Delete(int id);
    //    StateModel Find(int id);
    //    IEnumerable<StateModel> GetAll();
    //}
    //public class StateRepository : IStateRepository
    //{
    //    ToebEntities _db = new ToebEntities();
    //    public void Delete(int id)
    //    {
    //        try
    //        {
    //            var state = _db.States.Find(id);
    //            if (state == null) throw new Exception("State not found");

    //            _db.States.Remove(state);
    //            _db.Entry(state).State = EntityState.Deleted;
    //            SaveChanges();
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    public StateModel Find(int id)
    //    {
    //        try
    //        {
    //            var state = _db.States.Find(id);
    //            if (state == null) throw new Exception("State not found");

    //            return new StateModel()
    //            {
    //                Id = state.Id,
    //                Name = state.Name
    //            };
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    public IEnumerable<StateModel> GetAll()
    //    {
    //        //return _db.States.ToList().Select(c => new StateModel()
    //        //{
    //        //    Id=c.Id,
    //        //    Name=c.Name
    //        //}).ToList();

    //        var states = new List<StateModel>();
    //        foreach (var state in _db.States.ToList())
    //        {
    //            states.Add(new StateModel()
    //            {
    //                Id = state.Id,
    //                Name = state.Name
    //            });
    //        }
    //        return states;
    //    }

    //    public void Insert(StateModel model)
    //    {
    //        try
    //        {
    //            var state = new State();
    //            state.Name = model.Name;
    //            _db.States.Add(state);
    //            _db.Entry(state).State = EntityState.Added;
    //            SaveChanges();
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    //    private void SaveChanges()
    //    {
    //        _db.SaveChanges();
    //    }
    //    public void Update(StateModel model)
    //    {
    //        try
    //        {
    //            var state = _db.States.Find(model.Id);
    //            if (state == null)
    //                throw new Exception("State not found!");


    //            state.Name = model.Name;
    //            _db.Entry(state).State = EntityState.Modified;
    //            SaveChanges();
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    //}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;
using Toeb.Model.ViewModels;

namespace Toeb.BusinessLogic.Services
{
    public interface IStateService
    {
        void Create(StateModel model);
        void Delete(int id);
        void Update(StateModel model);
        IEnumerable<StateItem> GetAll();
        StateModel GetById(int id);
        StateItem GetDetails(int id);
    }
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public void Create(StateModel model)
        {
            try
            {
                if (_stateRepository.NameExist(model))
                    throw new Exception("State already exist!");

                var state = new State()
                {
                    Name = model.Name
                };
                _stateRepository.Insert(state);

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
                var state = _stateRepository.Find(id);
                if (state == null) throw new Exception("State not found!");

                _stateRepository.Delete(state);
            }
            catch (Exception ec)
            {

                throw;
            }
        }

        public IEnumerable<StateItem> GetAll()
        {
            return _stateRepository.GetAll().Select(c=> new StateItem()
            {
                Id=c.Id,
                Name=c.Name,
                EstateCount = c.Estates.Count
            });
        }

        public StateModel GetById(int id)
        {
            try
            {
                var state = _stateRepository.Find(id);
                if (state == null) throw new Exception("State not found");
                 
                return new StateModel() { Id = state.Id, Name = state.Name };
            }
            catch (Exception )
            {
                throw; 
            }
        }

        public StateItem GetDetails(int id)
        {
            try
            {
                var state = _stateRepository.Find(id);
                if (state == null) throw new Exception("State not found");

                return new StateItem() {
                    Id = state.Id,
                    Name = state.Name,
                    EstateCount =state.Estates.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(StateModel model)
        {
            try
            {
                if (_stateRepository.NameExist(model))
                    throw new Exception("State already exist!");

                var state = _stateRepository.Find(model.Id);
                if (state == null) throw new Exception("State not found!");

                state.Name = model.Name;
                _stateRepository.Update(state);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}

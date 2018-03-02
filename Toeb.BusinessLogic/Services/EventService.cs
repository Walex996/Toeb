using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;
using Toeb.Model.ViewModels;

namespace Toeb.BusinessLogic.Services
{
    public interface IEventService
    {
        void Create(EventModel model);
        void Delete(int id);
        void Update(EventModel model);
        IEnumerable<EventModel> GetAll();
        EventModel GetById(int id);
        EventItem GetDetails(int id);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Create(EventModel model)
        {
            try
            {
                if (_eventRepository.NameExist(model))
                    throw new Exception("Event already exists");
                var eevent = Mapper.Map<EventModel, Event>(model);
                _eventRepository.Insert(eevent);
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
                var eevent = _eventRepository.Find(id);
                if (eevent == null)
                    throw new Exception("Event not found");
                _eventRepository.Delete(eevent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<EventModel> GetAll()
        {
            var entities = _eventRepository.Table.ToList();
            return Mapper.Map<IEnumerable<Event>, IEnumerable<EventModel>>(entities);
        }

        public EventModel GetById(int id)
        {
            try
            {
                var eevent = _eventRepository.Find(id);
                if (eevent == null)
                    throw new Exception("Event not found");
                return Mapper.Map<Event, EventModel>(eevent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public EventItem GetDetails(int id)
        {
            try
            {
                var eevent = _eventRepository.Find(id);
                if (eevent == null) 
                    throw new Exception("Event not found");
                var item = Mapper.Map<Event, EventItem>(eevent);
                item.InvitedUserCount = eevent.InvitedUserIds.Count();
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(EventModel model)
        {
            try
            {
                if (_eventRepository.NameExist(model))
                    throw new Exception("Event already exist");
                var eevent = _eventRepository.Find(model.Id);
                if (eevent == null)
                    throw new Exception("Event not found");
                Mapper.Map(model, eevent);
                _eventRepository.Update(eevent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

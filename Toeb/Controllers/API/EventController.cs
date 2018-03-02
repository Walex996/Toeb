using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toeb.BusinessLogic.Services;
using Toeb.Model.ViewModels;
using Exception = System.Exception;

namespace Toeb.Controllers.API
{
    public class EventController : ApiController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_eventService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_eventService.GetById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IHttpActionResult Post(EventModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _eventService.Create(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IHttpActionResult Put(EventModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _eventService.Update(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _eventService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

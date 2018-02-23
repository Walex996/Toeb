using System;
using System.Web.Http;
using Toeb.BusinessLogic.Services;
using Toeb.Model.ViewModels;

namespace Toeb.Controllers.API
{
    public class StateController : ApiController
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_stateService.GetAll());
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_stateService.GetById(id));
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }

        public IHttpActionResult Post(StateModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _stateService.Create(model);
                return Ok(model);
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        public IHttpActionResult Put(StateModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _stateService.Update(model);
                return Ok(model);
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _stateService.Delete(id);
                return Ok();
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
    }
}

using System;
using System.Web.Http;
using Toeb.BusinessLogic.Services;
using Toeb.Model.ViewModels;
using Exception = System.Exception;

namespace Toeb.Controllers.API
{
    public class ServiceChargeController : ApiController
    {
        private readonly IServiceChargeService _serviceChargeService;

        public ServiceChargeController(IServiceChargeService serviceChargeService)
        {
            _serviceChargeService = serviceChargeService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_serviceChargeService.GetAll());
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
                return Ok(_serviceChargeService.GetById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IHttpActionResult Post(ServiceChargeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _serviceChargeService.Create(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(ServiceChargeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _serviceChargeService.Update(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _serviceChargeService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

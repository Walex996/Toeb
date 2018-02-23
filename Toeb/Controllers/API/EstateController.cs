using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toeb.BusinessLogic.Services;
using Toeb.Model.ViewModels;

namespace Toeb.Controllers.API
{
    public class EstateController : ApiController
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_estateService.GetAll());
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
                return Ok(_estateService.GetById(id));
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);

            }
        }

        public IHttpActionResult Post(EstateModel model)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                _estateService.Create(model);
                return Ok(model);
            }
            catch (Exception ec)
            {

                return BadRequest(ec.Message);
            }
        }

        public IHttpActionResult Put(EstateModel model)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                _estateService.Update(model);
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
                _estateService.Delete(id);
                return Ok();
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Toeb.BusinessLogic.Services;
using Toeb.Model.ViewModels;

namespace Toeb.Controllers.API
{
    [EnableCors("*","*","*")]
    public class EstateController : ApiController
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        //GET: api/estate
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

        //GET: api/estate/5
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

        //Post: api/estate
        public IHttpActionResult Post([FromBody]EstateModel model)
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


        public IHttpActionResult Put([FromBody]EstateModel model)
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

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
    public class ComplaintController : ApiController
    {
        private readonly ComplaintService _complaintService;

        public ComplaintController(ComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        //GET: api/complaint
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_complaintService.GetAll());
            }
            catch (Exception ec)
            {

                return BadRequest(ec.Message);
            }
        }

        //GET: api/complaint/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_complaintService.GetById(id));
            }
            catch (Exception ec)
            {

                return BadRequest(ec.Message);
            }
        }

        public IHttpActionResult Post([FromBody] ComplaintModel model)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                _complaintService.Create(model);
                return Ok(model);
            }
            catch (Exception ec)
            {

                return BadRequest(ec.Message);
            }
        }

        public IHttpActionResult Put([FromBody] ComplaintModel model)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                _complaintService.Update(model);
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
                _complaintService.Delete(id);
                return Ok();
            }
            catch (Exception ec)
            {

                return BadRequest(ec.Message);
            }
        }
    }
}

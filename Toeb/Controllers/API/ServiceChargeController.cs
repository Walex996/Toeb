using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;

namespace Toeb.Controllers
{
    public class ServiceChargeController : ApiController
    {
        private ServiceChargeRepository _serviceChargeRepository = new ServiceChargeRepository();

        public IQueryable<ServiceCharge> GetServiceCharges()
        {
            return _serviceChargeRepository.GetServiceCharges();
        }

        [ResponseType(typeof(ServiceCharge))]
        public ServiceCharge GetServiceCharge(int id)
        {
            var serviceCharge = _serviceChargeRepository.GetServiceCharge(id);
            return serviceCharge;
        }

        [ResponseType(typeof(ServiceCharge))]
        public IHttpActionResult CreateServiceCharge(ServiceCharge serviceCharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Content(HttpStatusCode.Created, _serviceChargeRepository.CreateServiceCharge(serviceCharge));
        }

        [HttpDelete]
        [ResponseType(typeof(ServiceCharge))]
        public IHttpActionResult DeleteServiceCharge(int id)
        {
            _serviceChargeRepository.DeleteServiceCharge(id);
            return Content(HttpStatusCode.NoContent, "");
        }

        [ResponseType(typeof(ServiceCharge))]
        public IHttpActionResult UpdateServiceCharge(int id, ServiceCharge serviceCharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _serviceChargeRepository.UpdateServiceCharge(id, serviceCharge);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

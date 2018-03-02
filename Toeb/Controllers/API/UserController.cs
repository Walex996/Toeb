using System;
using System.Web.Http;
using Toeb.BusinessLogic.Services;
using Toeb.Model.ViewModels;

namespace Toeb.Controllers.API
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Post(UserModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                _userService.Create(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _userService.Update(model);
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
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

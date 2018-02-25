//using System;
//using System.Web.Http;
//using Toeb.BusinessLogic.Services;
//using Toeb.Model.ViewModels;

//namespace Toeb.WebApp.Controllers.API
//{
//    public class AccountDetailController : ApiController
//    {
//        private readonly IAccountDetailService _accountDetailService;

//        public AccountDetailController(IAccountDetailService accountDetailService)
//        {
//            _accountDetailService = accountDetailService;
//        }

//        public IHttpActionResult Get()
//        {
//            try
//            {
//                return Ok(_accountDetailService.GetAll());
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public IHttpActionResult Get(int id)
//        {
//            try
//            {
//                return Ok(_accountDetailService.GetById(id));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public IHttpActionResult Post(AccountDetailModel model)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                    return BadRequest(ModelState);
//                _accountDetailService.Create(model);
//                return Ok(model);
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }

//        public IHttpActionResult Put(AccountDetailModel model)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                    return BadRequest(ModelState);
//                _accountDetailService.Update(model);
//                return Ok(model);
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }

//        public IHttpActionResult Delete(int id)
//        {
//            try
//            {
//                _accountDetailService.Delete(id);
//                return Ok();
//            }
//            catch (Exception e)
//            {
//                return BadRequest(e.Message);
//            }
//        }
//    }
//}

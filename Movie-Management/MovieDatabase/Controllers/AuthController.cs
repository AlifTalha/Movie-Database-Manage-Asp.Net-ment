//using BLL.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace MovieDatabase.Controllers
//{
//    public class AuthController : ApiController
//    {
//        [HttpGet]
//        [Route("api/test")]
//        public HttpResponseMessage Hash()
//        {
//            return Request.CreateResponse(HttpStatusCode.OK, AuthService.CreateMD5("1234"));
//        }

//        [HttpPost]
//        [Route("api/login")]
//        public HttpResponseMessage Login(UserDTO user)
//        {
//            var data = AuthService.Authenticate(user.Username, user.Password);
//            if (data != null)
//            {
//                return Request.CreateResponse(HttpStatusCode.OK, data);
//            }
//            return Request.CreateResponse(HttpStatusCode.NotFound);
//        }

//        [HttpPost]
//        [Route("api/logout")]
//        public HttpResponseMessage Logout(TokenDTO token)
//        {
//            var result = AuthService.Logout(token.Key);
//            if (result)
//            {
//                return Request.CreateResponse(HttpStatusCode.OK, "Logged out successfully");
//            }
//            return Request.CreateResponse(HttpStatusCode.BadRequest, "Logout failed");
//        }
//    }
//}

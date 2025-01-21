//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using BLL.DTOs;
//using BLL.Services;

//namespace MovieDatabase.Controllers
//{
//    public class AuthController : ApiController
//    {
//        //[HttpPost]
//        //[Route("api/auth/register")]
//        //public HttpResponseMessage Register(AuthDTO dto)
//        //{
//        //    if (AuthService.Register(dto))
//        //    {
//        //        return Request.CreateResponse(HttpStatusCode.OK, "Registration successful");
//        //    }
//        //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists");
//        //}
//        [HttpPost]
//        [Route("api/auth/register")]
//        public HttpResponseMessage Register(AuthDTO dto)
//        {
//            if (AuthService.Register(dto))
//            {
//                return Request.CreateResponse(HttpStatusCode.OK, "Registration successful");
//            }
//            return Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists or invalid data");
//        }


//        //[HttpPost]
//        //[Route("api/auth/login")]
//        //public HttpResponseMessage Login(AuthDTO dto)
//        //{
//        //    var token = AuthService.Login(dto);
//        //    if (token != null)
//        //    {
//        //        return Request.CreateResponse(HttpStatusCode.OK, new { Token = token });
//        //    }
//        //    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentials");
//        //}


//        [HttpPost]
//        [Route("api/auth/login")]
//        public HttpResponseMessage Login(AuthDTO dto)
//        {
//            var token = AuthService.Login(dto);
//            if (token != null)
//            {
//                return Request.CreateResponse(HttpStatusCode.OK, new
//                {
//                    Message = "Login successful",
//                    Token = token
//                });
//            }
//            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
//        }

//        [HttpPost]
//        [Route("api/auth/logout")]
//        public HttpResponseMessage Logout(string tokenKey)
//        {
//            var tokenRepo = DataAccessFactory.TokenRepo();
//            if (tokenRepo.InvalidateToken(tokenKey))
//            {
//                return Request.CreateResponse(HttpStatusCode.OK, "Logout successful");
//            }
//            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token or token already invalidated");
//        }





//    }
//}

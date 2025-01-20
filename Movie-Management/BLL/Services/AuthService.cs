//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Services
//{
//    internal class AuthService
//    {
//    }
//}


//using AutoMapper;
//using BLL.DTOs;
//using DAL;
//using DAL.EF.Tables;
//using System;
//using System.Linq;

//namespace BLL.Services
//{
//    public class AuthService
//    {
//        public static Mapper GetMapper()
//        {
//            var config = new MapperConfiguration(cfg => {
//                cfg.CreateMap<User, UserDTO>();
//                cfg.CreateMap<UserDTO, User>();
//            });
//            return new Mapper(config);
//        }

//        public static UserDTO Authenticate(string username, string password)
//        {
//            var repo = DataAccessFactory.UserRepo();
//            var user = repo.Get().FirstOrDefault(u => u.Username == username && u.Password == password);
//            return user != null ? GetMapper().Map<UserDTO>(user) : null;
//        }

//        public static string CreateMD5(string input)
//        {
//            using (var md5 = System.Security.Cryptography.MD5.Create())
//            {
//                var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
//                var hashBytes = md5.ComputeHash(inputBytes);
//                return Convert.ToHexString(hashBytes);
//            }
//        }

//        public static bool Logout(string tokenKey)
//        {
//            // Implement token invalidation logic if necessary
//            return true;
//        }
//    }
//}

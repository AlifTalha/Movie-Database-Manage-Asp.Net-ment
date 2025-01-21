//using System;
//using System.Security.Cryptography;
//using System.Text;
//using BLL.DTOs;
//using DAL;
//using DAL.EF.Tables;

//namespace BLL.Services
//{
//    public class AuthService
//    {
//        // Method to hash a password
//        private static string HashPassword(string password)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                var bytes = Encoding.UTF8.GetBytes(password);
//                var hash = sha256.ComputeHash(bytes);
//                return Convert.ToBase64String(hash);
//            }
//        }

//        // Method to register a new user
//        // Register
//        public static bool Register(AuthDTO dto)
//        {
//            var userRepo = DataAccessFactory.UserRepo();

//            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password) || string.IsNullOrWhiteSpace(dto.Email))
//                return false; // Ensure no empty fields

//            if (userRepo.GetByUsername(dto.Username) != null)
//                return false; // Username already exists

//            var hashedPassword = HashPassword(dto.Password);
//            var newUser = new User
//            {
//                Username = dto.Username,
//                Password = hashedPassword,
//                Email = dto.Email
//            };
//            return userRepo.Create(newUser);
//        }

//        // Login
//        public static string Login(AuthDTO dto)
//        {
//            var userRepo = DataAccessFactory.UserRepo();
//            var hashedPassword = HashPassword(dto.Password);

//            var user = userRepo.ValidateCredentials(dto.Username, hashedPassword);
//            if (user == null) return null;

//            var tokenRepo = DataAccessFactory.TokenRepo();
//            var token = new Token
//            {
//                Key = Guid.NewGuid().ToString(),
//                UserId = user.Id,
//                CreatedAt = DateTime.Now,
//                ExpiredAt = DateTime.Now.AddHours(1) // Example expiration time
//            };

//            return tokenRepo.Create(token) ? token.Key : null;
//        }










//    }
//}

using System;
using System.Security.Cryptography;
using System.Text;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;

namespace BLL.Services
{
    public class AuthService
    {
        // Method to hash a password
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Method to register a new user
        public static bool Register(AuthDTO dto)
        {
            var userRepo = DataAccessFactory.UserRepo();

            // Check if the username already exists
            if (userRepo.GetByUsername(dto.Username) != null)
                return false;

            // Hash the password before saving
            var hashedPassword = HashPassword(dto.Password);

            var newUser = new User
            {
                Username = dto.Username,
                Password = hashedPassword,
                Email = dto.Email
            };

            return userRepo.Create(newUser);
        }

        // Method to handle login
        public static string Login(AuthDTO dto)
        {
            var userRepo = DataAccessFactory.UserRepo();

            // Hash the password for validation
            var hashedPassword = HashPassword(dto.Password);

            // Validate the credentials
            var user = userRepo.ValidateCredentials(dto.Username, hashedPassword);

            if (user != null)
            {
                var tokenRepo = DataAccessFactory.TokenRepo();

                // Generate a new token
                var token = new Token
                {
                    Key = Guid.NewGuid().ToString(), // Unique token key
                    UserId = user.Id, // Link token to user
                    CreatedAt = DateTime.Now // Timestamp for token creation
                };


                // Save the token and return the key
                if (tokenRepo.Create(token))
                    return token.Key;
            }

            return null; // Return null if login fails
        }






 


    }
}

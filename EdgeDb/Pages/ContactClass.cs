using EdgeDB;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace EdgeDb.Pages
{
    public enum TitleEnum
    {
        Mr, Mrs, Ms, Dr
    }
    [EdgeDBType]
    public class ContactClass
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMarried { get; set; }
        public string DateofBirth { get; set; }
        public static string HashPassword (string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
   
}

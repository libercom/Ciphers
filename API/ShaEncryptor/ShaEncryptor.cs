using System.Text;

namespace API.ShaEncryptor
{
    public class ShaEncryptor : IShaEncryptor
    {
        public string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var secretBytes = Encoding.UTF8.GetBytes(password);
            var secretHash = sha256.ComputeHash(secretBytes);
            
            return Convert.ToHexString(secretHash);
        }
    }
}

namespace API.ShaEncryptor
{
    public interface IShaEncryptor
    {
        string HashPassword(string password);
    }
}

namespace API.Utils
{
    public class Encript
    {
        public static string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CompareHash(string passLogin, string passSql)
        {
            return BCrypt.Net.BCrypt.Verify(passLogin, passSql);
        }
    }
}

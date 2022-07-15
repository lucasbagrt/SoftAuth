using SoftAuth.Utils;

namespace SoftAuth.Helpers
{
    public static class Module
    {        
        public static string Encrypt(string text)
        {
            try
            {
                return BCrypt.Net.BCrypt.HashPassword(text);                
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return "";
            }
        }        
        public static bool CompareEncryptedString(string hash, string text)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(text, hash);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }
    }
}

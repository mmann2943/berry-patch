using System.Security.Cryptography;
using System.Text;

namespace BerryPatch.Web
{
    public class MD5Helper: ICryptoHelper
    {
        public string Encrypt(string password)
        {            
            var md5 = new MD5CryptoServiceProvider();
            var encoding = new UTF8Encoding();
            var bytes = encoding.GetBytes(password);
            return encoding.GetString(md5.ComputeHash(bytes));
        }
    }
}
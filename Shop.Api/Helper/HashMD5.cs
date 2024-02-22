using System.Text;
using XSystem.Security.Cryptography;

namespace Shop.Api.Helper
{
    public class HashMD5
    {
        public string GetMD5(string str)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(string.Format("{0:x2}", b));

            }

            return sbHash.ToString();

        }
    }
}

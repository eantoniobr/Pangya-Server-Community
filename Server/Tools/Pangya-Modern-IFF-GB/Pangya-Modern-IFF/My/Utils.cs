using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace PangyaSuiteFiles.My
{
    public static class Helper
    {

       public static string MD5Hash(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public static Size GetSize(int width, int height)
        { 
            var size = new Size(width, height);
            return size;
        }
    }
}

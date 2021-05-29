using System;
using System.Text;

namespace Md5Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input password: ");
            string pass = Console.ReadLine();
            string md5string = CreateMD5(pass);
            Console.WriteLine("Password encrypted: {0}", md5string);
        }
        public static string CreateMD5(string input)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(input)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }
    }
}

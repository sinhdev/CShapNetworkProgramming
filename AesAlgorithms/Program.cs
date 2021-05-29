using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesAlgorithms
{
    class Program
    {
        public static class Global
        {
            public const String STRING_PERMUTATION = "sinhnx.dev";
            public const Int32 BYTE_PERMUTATION_1 = 0x19;
            public const Int32 BYTE_PERMUTATION_2 = 0x59;
            public const Int32 BYTE_PERMUTATION_3 = 0x17;
            public const Int32 BYTE_PERMUTATION_4 = 0x41;
        }
        public static void Main(String[] args)
        {
            // input a string to encrypt.
            Console.Write("input a message: ");
            string msg = Console.ReadLine();

            string strEncrypted = (Encrypt(msg));
            Console.WriteLine("encrypted message: " + strEncrypted);

            string strDecrypted = (Decrypt(strEncrypted));
            Console.WriteLine("decrypted message: " + strDecrypted);
        }
        // encoding
        public static string Encrypt(string strData)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
        }
        // decoding
        public static string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        }
        // encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(Global.STRING_PERMUTATION,
            new byte[] { Global.BYTE_PERMUTATION_1,
                         Global.BYTE_PERMUTATION_2,
                         Global.BYTE_PERMUTATION_3,
                         Global.BYTE_PERMUTATION_4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(Global.STRING_PERMUTATION,
            new byte[] { Global.BYTE_PERMUTATION_1,
                         Global.BYTE_PERMUTATION_2,
                         Global.BYTE_PERMUTATION_3,
                         Global.BYTE_PERMUTATION_4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
    }
}
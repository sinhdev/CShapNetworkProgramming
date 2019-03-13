using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DesAlgorithms
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new DESCryptoServiceProvider object
                // to generate a key and initialization vector (IV).
                DESCryptoServiceProvider DESalg = new DESCryptoServiceProvider();

                // input a string to encrypt.
                Console.Write("input a message: ");
                string sData = Console.ReadLine();

                // Encrypt the string to an in-memory buffer.
                // byte[] Data = EncryptTextToMemory(sData, DESalg.Key, DESalg.IV);
                // string encrypted = Convert.ToBase64String(Data);
                string encrypted = EncryptText(sData, DESalg.Key, DESalg.IV);
                Console.WriteLine("encrypted message: "+ encrypted);

                // Decrypt the buffer back to a string.
                // string Final = DecryptTextFromMemory(Data, DESalg.Key, DESalg.IV);
                // Display the decrypted string to the console.
                // Console.WriteLine(Final);
                Console.WriteLine("decrypted message: " + DecryptText(encrypted, DESalg.Key, DESalg.IV));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static string EncryptText(string Data, byte[] Key, byte[] IV)
        {
            return Convert.ToBase64String(EncryptTextToMemory(Data, Key, IV));
        }
        public static string DecryptText(string sData, byte[] Key, byte[] IV)
        {
            byte[] Data = Convert.FromBase64String(sData);
            return DecryptTextFromMemory(Data, Key, IV);
        }
        public static byte[] EncryptTextToMemory(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new DESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = Encoding.UTF8.GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new DESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return Encoding.UTF8.GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
    }
}

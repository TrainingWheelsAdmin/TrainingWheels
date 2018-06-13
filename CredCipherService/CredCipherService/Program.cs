using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Threading.Tasks;

namespace CredCipherService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Write("EncriptionText: ");
                string original = Console.ReadLine();

                // key and initialization vector (IV).
                string keyHex = "3EC6C8B454C531762E44364F1CFCD80094827723BF3963D764B77FE73692C6CB";
                string initVectorHex = "20300E2B612FDFF5E874B54B78760661";

                byte[] key = Enumerable.Range(0, keyHex.Length).Where(w => w % 2 == 0).Select(s => Convert.ToByte(keyHex.Substring(s, 2), 16)).ToArray();
                byte[] IV = Enumerable.Range(0, initVectorHex.Length).Where(w => w % 2 == 0).Select(s => Convert.ToByte(initVectorHex.Substring(s, 2), 16)).ToArray();
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(original, key, IV);

                string result = System.Text.Encoding.UTF8.GetString(encrypted);
                string hex = BitConverter.ToString(encrypted);
                hex = BitConverter.ToString(encrypted).Replace("-", string.Empty);
                // Decrypt the bytes to a string.
                byte[] encrypted_duplicate = Enumerable.Range(0, hex.Length)
                 .Where(x => x % 2 == 0)
                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                 .ToArray();
                string roundtrip = DecryptStringFromBytes_Aes(encrypted_duplicate, key, IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
                Console.WriteLine("CipherText: " + hex);
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
        public bool AddAdminCred(string TenantId, string UserName, string Password, string UserId)
        {
            bool insertStatus = false;
            return insertStatus;
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}

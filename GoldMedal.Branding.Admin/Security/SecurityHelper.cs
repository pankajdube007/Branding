using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GoldMedal.Branding.Admin.Security
{
    public class SecurityHelper
    {
        #region Utilities

        private static byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write);
            byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
            byte[] ret = mStream.ToArray();
            cStream.Close();
            mStream.Close();
            return ret;
        }

        private static string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            var msDecrypt = new MemoryStream(data);
            var csDecrypt = new CryptoStream(msDecrypt, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read);
            var sReader = new StreamReader(csDecrypt, new UnicodeEncoding());
            return sReader.ReadLine();
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// Decrypts text
        /// </summary>
        /// <param name="cipherText">Cipher text</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Decrypted string</returns>
        public static string Decrypt(string cipherText, string encryptionPrivateKey)
        {
            if (String.IsNullOrEmpty(cipherText))
                return cipherText;

            var tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] buffer = Convert.FromBase64String(cipherText);
            string result = DecryptTextFromMemory(buffer, tDESalg.Key, tDESalg.IV);
            return result;
        }

        /// <summary>
        /// Encrypts text
        /// </summary>
        /// <param name="plainText">Plaint text</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string plainText, string encryptionPrivateKey)
        {
            if (String.IsNullOrEmpty(plainText))
                return plainText;

            var tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] encryptedBinary = EncryptTextToMemory(plainText, tDESalg.Key, tDESalg.IV);
            string result = Convert.ToBase64String(encryptedBinary);
            return result;
        }

        #endregion Methods
    }
}
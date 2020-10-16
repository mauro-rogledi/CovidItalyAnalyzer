using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CovidItalyAnalyzer.Library
{
    public static class Crypting
    {
        private static string CryptoData = "skjdhdydk7snsj!";

        public static string Encrypt(string dText)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(dText);
            PasswordDeriveBytes passwordDeriveByte =
                new PasswordDeriveBytes(CryptoData,
                    new byte[] { 0x44, 0x6f, 0x74, 0x4e, 0x65, 0x74, 0x57,
                0x6f, 0x72, 0x6b, 0x65, 0x72, 0x73, 0x2e, 0x47,
                0x6f, 0x74, 0x74, 0x61 });
            byte[] encryptedArray = Encrypt(bytes,
                passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16));
            return Convert.ToBase64String(encryptedArray);
        }

        public static string Decrypt(string eText)
        {
            if (eText == "")
                return "";

            byte[] dataArray = Convert.FromBase64String(eText);
            PasswordDeriveBytes passwordDeriveByte =
                new PasswordDeriveBytes(CryptoData,
                    new byte[] { 0x44, 0x6f, 0x74, 0x4e, 0x65, 0x74, 0x57,
                0x6f, 0x72, 0x6b, 0x65, 0x72, 0x73, 0x2e, 0x47, 0x6f,
                0x74, 0x74, 0x61 });
            byte[] hiddenArray = Decrypt(dataArray,
                passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16));
            return Encoding.Unicode.GetString(hiddenArray);
        }

        private static byte[] Encrypt(byte[] dData, byte[] outerKey, byte[] IV)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Rijndael key = Rijndael.Create();
                key.Key = outerKey;
                key.IV = IV;

                using (CryptoStream cryptoStream =
                    new CryptoStream(memoryStream, key.CreateEncryptor(),
                        CryptoStreamMode.Write))
                {
                    cryptoStream.Write(dData, 0, (int)dData.Length);
                    cryptoStream.Close();
                }
                byte[] array = memoryStream.ToArray();
                return array;
            }
        }

        private static byte[] Decrypt(byte[] eData, byte[] outerKey, byte[] IV)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Rijndael key = Rijndael.Create();
                key.Key = outerKey;
                key.IV = IV;
                using (CryptoStream cryptoStream =
                    new CryptoStream(memoryStream, key.CreateDecryptor(),
                        CryptoStreamMode.Write))
                {
                    cryptoStream.Write(eData, 0, (int)eData.Length);
                    cryptoStream.Close();
                }
                byte[] array = memoryStream.ToArray();
                return array;
            }
        }
    }
}
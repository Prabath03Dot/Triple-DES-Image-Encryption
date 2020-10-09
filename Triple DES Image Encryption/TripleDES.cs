using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Triple_DES_Image_Encryption
{
    public class TripleDES
    {
        private TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();

        public TripleDES(string key)
        {
            tripleDes.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDes.Mode = CipherMode.ECB;
            tripleDes.Padding = PaddingMode.PKCS7;
        }

        public void EncryptFile(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] eBytes = tripleDes.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, eBytes);
        }

        public void DecryptFile(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] dBytes = tripleDes.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, dBytes);
        }
    }
}

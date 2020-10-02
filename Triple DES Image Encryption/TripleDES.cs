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
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

        public TripleDES(string key)
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
        }

        public void EncryptFile(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] eBytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, eBytes);
        }

        public void DecryptFile(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] dBytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, dBytes);
        }
    }
}

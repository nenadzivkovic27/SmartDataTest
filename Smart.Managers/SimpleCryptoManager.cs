using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace Smart.Managers
{

    public class SimpleCryptoManager : ICryptoManager
    {
        private static SimpleCryptoManager instance = null;
        private static readonly object padlock = new object();

        public static SimpleCryptoManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SimpleCryptoManager();
                    }
                    return instance;
                }
            }
        }

        private byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public  string Encrypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public  string Decrypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}


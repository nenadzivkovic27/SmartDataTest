namespace Smart.Managers
{
    public interface ICryptoManager
    {
        public string Decrypt(string cipherText);
        public string Encrypt(string plainText);
    }
}
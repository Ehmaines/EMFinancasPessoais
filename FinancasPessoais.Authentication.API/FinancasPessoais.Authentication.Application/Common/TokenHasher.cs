using System.Security.Cryptography;
using System.Text;

namespace FinancasPessoais.Authentication.Application.Common
{
    public static class Cryptography
    {
        //Pegar Key e IV das variáveis de ambiente
        public static byte[] Key = Encoding.UTF8.GetBytes(">^CJ$EyM9<x*MeggBY#-?wK33@,-C>Us");//Environment.GetEnvironmentVariable("Emaines.FinancasPessoais.KEY"));
        public static byte[] IV = Encoding.UTF8.GetBytes("1981974657672585");//Environment.GetEnvironmentVariable("Emaines.FinancasPessoais.IV"));

        public static string Encrypt(string text)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs, Encoding.UTF8))
            sw.Write(text);
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipher)
        {
            byte[] buffer = Convert.FromBase64String(cipher);
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            using var ms = new MemoryStream(buffer);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);
            return sr.ReadToEnd();
        }
    }
}

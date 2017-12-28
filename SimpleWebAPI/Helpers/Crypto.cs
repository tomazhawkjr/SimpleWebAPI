using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SimpleWebAPI.API.Helpers
{
    public class Crypto
    {

        private RSACryptoServiceProvider rsaProvider;

        public Crypto()
        {
            this.rsaProvider = new RSACryptoServiceProvider();
        }

        public void importarKey(string key)
        {
            this.rsaProvider.FromXmlString(key);
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }

        public string[] gerarChaves()
        {
            // [0] = chave publica, [1] = chave privada
            string[] chaves = new string[2];

            CspParameters cspParams = null;
            rsaProvider = null;

            try
            {
                // Create a new key pair on target CSP
                cspParams = new CspParameters();

                cspParams.ProviderType = 1; // PROV_RSA_FULL

                //cspParams.ProviderName; // CSP name
                cspParams.Flags = CspProviderFlags.UseArchivableKey;

                cspParams.KeyNumber = (int)KeyNumber.Exchange;

                rsaProvider = new RSACryptoServiceProvider(2048, cspParams);

                // Export public key
                chaves[0] = rsaProvider.ToXmlString(false);

                // Export private/public key pair
                chaves[1] = rsaProvider.ToXmlString(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return chaves;
        }

        public string encriptar(string conteudo)
        {
            var decryptedBytes = System.Text.Encoding.UTF8.GetBytes(conteudo);
            var encryptedBytes = this.rsaProvider.Encrypt(decryptedBytes, true);

            return System.Convert.ToBase64String(encryptedBytes);
        }

        public string decriptar(string cifra)
        {
            var encriptedBytes = System.Convert.FromBase64String(cifra);
            var decriptedBytes = this.rsaProvider.Decrypt(encriptedBytes, true);

            return System.Text.Encoding.UTF8.GetString(decriptedBytes);
        }
    }
}
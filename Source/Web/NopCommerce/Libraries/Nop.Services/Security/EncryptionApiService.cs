using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Security
{
    public partial class EncryptionApiService : IEncryptionService
    {
        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        public virtual string CreateSaltKey(int size)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("size", size);
            return APIHelper.Instance.GetAsync<string>("Security", "CreateSaltKey", parameters);
        }

        /// <summary>
        /// Create a password hash
        /// </summary>
        /// <param name="password">{assword</param>
        /// <param name="saltkey">Salk key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        public virtual string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            var body = new
            {
                password,
                saltkey,
                passwordFormat
            };
            
            return APIHelper.Instance.PostAsync<string>("Security", "CreatePasswordHash",body, null);
        }

        /// <summary>
        /// Create a data hash
        /// </summary>
        /// <param name="data">The data for calculating the hash</param>
        /// <param name="hashAlgorithm">Hash algorithm</param>
        /// <returns>Data hash</returns>
        public virtual string CreateHash(byte[] data, string hashAlgorithm = "SHA1")
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("data", data);
            parameters.Add("hashAlgorithm", hashAlgorithm);
            return APIHelper.Instance.GetAsync<string>("Security", "CreateHash", parameters);
        }

        /// <summary>
        /// Encrypt text
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Encrypted text</returns>
        public virtual string EncryptText(string plainText, string encryptionPrivateKey = "")
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("plainText", plainText);
            parameters.Add("encryptionPrivateKey", encryptionPrivateKey);
            return APIHelper.Instance.GetAsync<string>("Security", "EncryptText", parameters);
        }

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="cipherText">Text to decrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Decrypted text</returns>
        public virtual string DecryptText(string cipherText, string encryptionPrivateKey = "")
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("cipherText", cipherText);
            parameters.Add("encryptionPrivateKey", encryptionPrivateKey);
            return APIHelper.Instance.GetAsync<string>("Security", "DecryptText", parameters);
        }
    }
}

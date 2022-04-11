using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace web_api_project_activos_fijos.Services
{
    public class HashService
    {
        public ResultadoHash Hash(string textoplano)
        {
            var sal = new byte[16];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(sal);
            }

            return Hash(textoplano, sal);
        }

        public ResultadoHash Hash(string textoplano, byte[] sal)
        {
            var llaveDerivada = KeyDerivation.Pbkdf2(password: textoplano,
                salt: sal, prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 32);

            var hash = Convert.ToBase64String(llaveDerivada);

            return new ResultadoHash
            {
                Hash = hash,
                Sal = sal
            };
        }
    }
}

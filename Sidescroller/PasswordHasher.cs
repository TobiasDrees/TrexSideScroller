using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sidescroller
{
    class PasswordHasher
    {
        private const int SALT_SIZE  = 16;
        private const int HASH_SIZE  = 20;
        private const int ITERATIONS = 10000;

        public static string Hash(string password)
        {
            return Hash(password, ITERATIONS);
        }

        private static string Hash(string password, int iterations)
        {
            // Create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SALT_SIZE]);
            
            // Create Hash
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

            // Combine Salt and Hash
            byte[] hashBytes = new byte[SALT_SIZE + HASH_SIZE];
            Array.Copy(salt, 0, hashBytes, 0, SALT_SIZE);
            Array.Copy(hash, 0, hashBytes, SALT_SIZE, HASH_SIZE);
            
            // Format hash with extra information
            return String.Format("$RFCHASH$V1${0}${1}", iterations, Convert.ToBase64String(hashBytes));
        }

        public static bool isValidHash(string hash) {
            return hash.Contains("$RFCHASH$V1$");
        }

        public static bool VerifyHash(string password, string hashedPassword)
        {
            // Check hash
            if (!isValidHash(hashedPassword))
                throw new NotSupportedException("The hashtype is not supported");

            // Extract iteration and Base64
            string[] splittedHashString = hashedPassword.Replace("$RFCHASH$V1$", "").Split('$');
            string base64Hash = splittedHashString[1];

            // Get hashbytes
            byte[] hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt
            byte[] salt = new byte[SALT_SIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALT_SIZE);

            // Create hash with given salt
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS);
            byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

            // Get result
            for (int i = 0; i < HASH_SIZE; i++)
            {
                if (hashBytes[i + SALT_SIZE] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

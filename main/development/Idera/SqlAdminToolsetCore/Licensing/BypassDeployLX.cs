using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Idera.SqlAdminToolset.Core.Licensing
{
    class BypassDeployLX
    {
        private const string constKey = "991188223377446655";

        public static bool IsLicensed()
        {
            string product = "SQLadminToolset";
            try
            {
                using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Idera\\" + product))
                {
                    string license = QuickDecrypt((string)registryKey.GetValue("AlternateLicense"));
                    if (string.IsNullOrEmpty(license)) return (false);
                    string[] parts = license.Split('\n');
                    if (null == parts) return (false);
                    if (parts.Length < 3) return (false);
                    if (0 != string.Compare(parts[0].Trim(), product.Trim(), true)) return (false);
                    if (0 != string.Compare(parts[2].Trim(), Environment.MachineName.Trim(), true)) return (false);
                    DateTime dt = DateTime.FromBinary(Convert.ToInt64(parts[1]));
                    if (dt == DateTime.MinValue || dt == DateTime.MaxValue) return (false);
                    if (dt < DateTime.UtcNow) return (false);
                    if (dt > DateTime.UtcNow.AddYears(3)) return (false);
                    return (true);
                }
            }
            catch { }
            return (false);
        }

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        internal static string QuickEncrypt(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
            {
                return (plaintext);
            }
            string encrypted;
            try
            {
                using (TripleDES algorithm = System.Security.Cryptography.TripleDESCryptoServiceProvider.Create())
                {
                    try
                    {
                        algorithm.Mode = CipherMode.ECB;
                        algorithm.Key = GenerateKey(algorithm);
                        using (ICryptoTransform transform = algorithm.CreateEncryptor())
                        {
                            byte[] buffer = UnicodeEncoding.Unicode.GetBytes(plaintext);
                            buffer = transform.TransformFinalBlock(buffer, 0, buffer.Length);
                            encrypted = Convert.ToBase64String(buffer);
                        }
                    }
                    finally
                    {
                        algorithm.Clear();
                    }
                }
            }
            catch
            {
                throw;
            }
            return (encrypted);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        private static string QuickDecrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                return (encryptedText);
            }
            string plaintext;
            using (TripleDES algorithm = System.Security.Cryptography.TripleDESCryptoServiceProvider.Create())
            {
                try
                {
                    algorithm.Mode = CipherMode.ECB;
                    algorithm.Key = GenerateKey(algorithm);
                    // Decrypt encrypted byte buffer and return ASCII string
                    using (ICryptoTransform transform = algorithm.CreateDecryptor())
                    {
                        // Base64 decode and decrypt the encrypted string
                        byte[] buffer = Convert.FromBase64String(encryptedText);
                        buffer = transform.TransformFinalBlock(buffer, 0, buffer.Length);
                        plaintext = UnicodeEncoding.Unicode.GetString(buffer);
                    }
                }
                finally
                {
                    algorithm.Clear();
                }
            }
            return (plaintext);
        }

        /// <summary>
        /// Generates the key.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns></returns>
        /// <remarks>
        /// Depending on the legal key size limitations of a specific CryptoService provider
        /// and length of the private key provided, padding the secret key with space character
        /// to meet the legal size of the algorithm.
        /// </remarks>
        private static byte[] GenerateKey(SymmetricAlgorithm algorithm)
        {
            string sTemp;
            KeySizes firstLegalKeySizes = algorithm.LegalKeySizes[0];
            if (algorithm.LegalKeySizes.Length > 0)
            {
                int moreSize = firstLegalKeySizes.MinSize;
                // key sizes are in bits
                while (constKey.Length * 8 > moreSize)
                {
                    moreSize += firstLegalKeySizes.SkipSize;
                }
                sTemp = constKey.PadRight(moreSize / 8, ' ');
            }
            else
            {
                sTemp = constKey;
            }

            // convert the secret key to byte array
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

    }
}

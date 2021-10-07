using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Idera.SqlAdminToolset.Core
{
    /// <summary>
    /// The encryption type enumeration
    /// </summary>
    [Serializable]
    public enum EncryptionType
    {
        None,
        Rijndael,
        RC2,
        DES,
        TripleDES
    }

    public static class EncryptionHelper {
        #region Public static methods

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        public static string QuickEncrypt(string plaintext) {
            return QuickEncryptInternal(plaintext);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        public static string QuickDecrypt(string encryptedText) {
            return QuickDecryptInternal(encryptedText);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="unicode">if set to <c>true</c> [unicode].</param>
        /// <returns></returns>
        public static string QuickDecrypt(string encryptedText, bool unicode) {
            return QuickDecryptInternal(encryptedText, unicode);
        }

        /// <summary>
        /// Encrypts the backup password.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        public static string EncryptBackupPassword(string plaintext) {
            return QuickEncryptInternal(plaintext, EncryptionType.RC2);
        }

        /// <summary>
        /// Decrypts the backup password.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        public static string DecryptBackupPassword(string encryptedText) {
            return QuickDecryptInternal(encryptedText, EncryptionType.RC2);
        }

        /// <summary>
        /// Encrypts the restore password.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        public static string EncryptRestorePassword(string plaintext) {
            return QuickEncryptInternal(plaintext, EncryptionType.Rijndael);
        }

        /// <summary>
        /// Decrypts the restore password.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        public static string DecryptRestorePassword(string encryptedText) {
            return QuickDecryptInternal(encryptedText, EncryptionType.Rijndael);
        }

        /// <summary>
        /// Encrypts the SQL password.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        public static string EncryptSqlPassword(string plaintext) {
            return QuickEncryptInternal(plaintext, EncryptionType.DES);
        }

        /// <summary>
        /// Decrypts the SQL password.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        public static string DecryptSqlPassword(string encryptedText) {
            return QuickDecryptInternal(encryptedText, EncryptionType.DES);
        }

        /// <summary>
        /// Encrypts the windows password.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        public static string EncryptWindowsPassword(string plaintext) {
            return QuickEncryptInternal(plaintext, EncryptionType.TripleDES);
        }

        /// <summary>
        /// Decrypts the windows password.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        public static string DecryptWindowsPassword(string encryptedText) {
            return QuickDecryptInternal(encryptedText, EncryptionType.TripleDES);
        }

        #endregion

        #region Quick encrypt/decrypt/hash (THESE MUST STAY INTERNAL/PRIVATE!!!)

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="plaintext">The plaintext.</param>
        /// <returns></returns>
        internal static string QuickEncryptInternal(string plaintext) {
            return QuickEncryptInternal(plaintext, EncryptionType.TripleDES);
        }

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="plaintext">The plaintext string</param>
        /// <param name="encryptionType">Type of the encryption.</param>
        /// <returns>The encrypted string</returns>
        /// <remarks>Uses TripleDES encryption, with hardcoded private key.</remarks>
        internal static string QuickEncryptInternal(string plaintext, EncryptionType encryptionType) {
            if (plaintext == null) {
                return null;
            }

            string encrypted;
            using (SymmetricAlgorithm algorithm = CryptoServiceProviderFactory.GetCryptoServiceProvider(encryptionType)) {
                try {
                    // Encrypt the string and base64 encode the encrypted string
                    // for platform independence
                    byte[] buffer = UnicodeEncoding.Unicode.GetBytes(plaintext);
                    using (ICryptoTransform transform = algorithm.CreateEncryptor()) {
                        encrypted = Convert.ToBase64String(transform.TransformFinalBlock(buffer, 0, buffer.Length));
                    }
                } finally {
                    algorithm.Clear();
                }
            }

            return encrypted;
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        internal static string QuickDecryptInternal(string encryptedText) {
            return QuickDecryptInternal(encryptedText, true, EncryptionType.TripleDES);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="unicode">if set to <c>true</c> [unicode].</param>
        /// <returns></returns>
        internal static string QuickDecryptInternal(string encryptedText, bool unicode) {
            return QuickDecryptInternal(encryptedText, unicode, EncryptionType.TripleDES);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="encryptionType">Type of the encryption.</param>
        /// <returns></returns>
        internal static string QuickDecryptInternal(string encryptedText, EncryptionType encryptionType) {
            return QuickDecryptInternal(encryptedText, true, encryptionType);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="encryptedtext">The encrypted string</param>
        /// <param name="unicode">if set to <c>true</c> [unicode].</param>
        /// <param name="encryptionType">Type of the encryption.</param>
        /// <returns>The decrypted string</returns>
        internal static string QuickDecryptInternal(string encryptedtext,
                                                    bool unicode,
                                                    EncryptionType encryptionType) {
            if (encryptedtext == null) {
                return null;
            }

            string plaintext;
            using (SymmetricAlgorithm algorithm = CryptoServiceProviderFactory.GetCryptoServiceProvider(encryptionType)) {
                try {
                    // Base64 decode and decrypt the encrypted string
                    byte[] buffer = Convert.FromBase64String(encryptedtext);

                    // Decrypt encrypted byte buffer and return ASCII string
                    using (ICryptoTransform transform = algorithm.CreateDecryptor()) {
                        if (unicode) {
                            plaintext =
                                UnicodeEncoding.Unicode.GetString(
                                    transform.TransformFinalBlock(buffer, 0, buffer.Length));
                        } else {
                            plaintext =
                                ASCIIEncoding.ASCII.GetString(transform.TransformFinalBlock(buffer, 0, buffer.Length));
                        }
                    }
                } finally {
                    algorithm.Clear();
                }
            }

            return plaintext;
        }

        #endregion
    }

    internal static class CryptoServiceProviderFactory {
        #region Private static variables

        private const string constKey = "SQLdefrag";

        #endregion

        #region Internal static methods

        /// <summary>
        /// Returns a new instance of the derived class: SymmetricAlgorithm
        /// Note: The caller is responsible for doing a clear/dispose to release resources
        /// </summary>
        /// <param name="encryptionType">Type of the encryption.</param>
        /// <returns>SymmetricAlgorithm instance</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")]
        internal static SymmetricAlgorithm GetCryptoServiceProvider(EncryptionType encryptionType) {
            SymmetricAlgorithm algorithm = null;

            try {
                switch (encryptionType) {
                    case EncryptionType.Rijndael:
                        algorithm = new RijndaelManaged();
                        algorithm.Key = GenerateKey(algorithm);
                        break;

                    case EncryptionType.DES:
                        algorithm = new DESCryptoServiceProvider();
                        algorithm.Key = GenerateKey(algorithm);
                        break;

                    case EncryptionType.RC2:
                        algorithm = new RC2CryptoServiceProvider();
                        algorithm.Key = GenerateKey(algorithm);
                        break;

                    case EncryptionType.TripleDES:
                        // We derive this a different way, for backwards-compatibility with previous QuickEncrypt/QuickDecrypt
                        algorithm = new TripleDESCryptoServiceProvider();
                        using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider()) {
                            algorithm.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(constKey));
                            hashmd5.Clear();
                        }
                        break;
                }

                if (algorithm == null) {
                    throw new Exception("Encryption algorithm could not be initialized");
                }

                algorithm.Mode = CipherMode.ECB;
                return algorithm;
            } catch {
                if (algorithm != null) {
                    algorithm.Clear();
                }
                throw;
            }
        }

        #endregion

        #region Private methods

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
        private static byte[] GenerateKey(SymmetricAlgorithm algorithm) {
            string sTemp;
            KeySizes firstLegalKeySizes = algorithm.LegalKeySizes[0];
            if (algorithm.LegalKeySizes.Length > 0) {
                int moreSize = firstLegalKeySizes.MinSize;
                // key sizes are in bits
                while (constKey.Length * 8 > moreSize) {
                    moreSize += firstLegalKeySizes.SkipSize;
                }
                sTemp = constKey.PadRight(moreSize / 8, ' ');
            } else {
                sTemp = constKey;
            }

            // convert the secret key to byte array
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        #endregion
    }
}
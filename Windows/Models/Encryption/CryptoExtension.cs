namespace Windows.Models.Encryption
{
    public static class CryptoExtension
    {
        /// <summary>
        /// Encrypts a string value generating a base64-encoded string.
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted.</param>
        /// <param name="passphrase">The passphrase.</param>
        /// <returns>
        /// Cipher text formatted as a base64-encoded string.
        /// </returns>
        public static string Encrypt(this string plainText, string passphrase)
        {
            using (var crypto = new DataCrypto(passphrase))
            {
                return crypto.Encrypt(plainText);
            }
        }

        /// <summary>
        /// Decrypts a base64-encoded cipher text value generating a string result.
        /// </summary>
        /// <param name="encryptedText">Base64-encoded cipher text string to be decrypted.</param>
        /// <param name="passphrase">The passphrase.</param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        public static string Decrypt(this string encryptedText, string passphrase)
        {
            using (var crypto = new DataCrypto(passphrase))
            {
                return crypto.Decrypt(encryptedText);
            }
        }
    }
}

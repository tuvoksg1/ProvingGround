using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Windows.Models.Encryption
{
    /// <summary>
    /// This class uses a symmetric key algorithm (Rijndael/AES) to encrypt and
    /// decrypt data. As long as it is initialized with the same constructor
    /// parameters, the class will use the same key. Before performing encryption,
    /// the class can prepend random bytes to plain text and generate different
    /// encrypted values from the same plain text, encryption key, initialization
    /// vector, and other parameters. This class is thread-safe.
    /// </summary>
    public class DataCrypto : IDisposable
    {
        // If key size is not specified, use the longest 256-bit key.
        private const int DefaultKeySize = 256;

        // Do not allow salt to be longer than 255 bytes, because we have only
        // 1 byte to store its length. 
        private const int MaxAllowedSaltLength = 255;

        // Do not allow salt to be smaller than 4 bytes, because we use the first
        // 4 bytes of salt to store its length. 
        private const int MinAllowedSaltLength = 4;

        // Random salt value will be between 4 and 8 bytes long.
        private const int DefaultMinSaltLength = MinAllowedSaltLength;
        private const int DefaultMaxSaltLength = 8;

        // Use these members to save min and max salt lengths.
        private readonly int _minSaltLength;
        private readonly int _maxSaltLength;

        // These members will be used to perform encryption and decryption.
        private readonly ICryptoTransform _encryptor;
        private readonly ICryptoTransform _decryptor;

        /// <summary>
        /// Use this constructor if you are planning to perform encryption/
        /// decryption with the key derived from the explicitly specified
        /// parameters.
        /// </summary>
        /// <param name="passPhrase">Passphrase from which a pseudo-random password will be derived.
        /// The derived password will be used to generate the encryption key
        /// Passphrase can be any string. In this example we assume that the
        /// passphrase is an ASCII string. Passphrase value must be kept in
        /// secret.</param>
        /// <param name="initializationVector">Initialization vector (IV). This value is required to encrypt the
        /// first block of plaintext data. For RijndaelManaged class IV must be
        /// exactly 16 ASCII characters long. IV value does not have to be kept
        /// in secret.</param>
        /// <param name="minSaltLength">Min size (in bytes) of randomly generated salt which will be added at
        /// the beginning of plain text before encryption is performed. When this
        /// value is less than 4, the default min value will be used (currently 4
        /// bytes).</param>
        /// <param name="maxSaltLength">Max size (in bytes) of randomly generated salt which will be added at
        /// the beginning of plain text before encryption is performed. When this
        /// value is negative or greater than 255, the default max value will be
        /// used (currently 8 bytes). If max value is 0 (zero) or if it is smaller
        /// than the specified min value (which can be adjusted to default value),
        /// salt will not be used and plain text value will be encrypted as is.
        /// In this case, salt will not be processed during decryption either.</param>
        /// <param name="keySize">Size of symmetric key (in bits): 128, 192, or 256.</param>
        /// <param name="saltValue">Salt value used for password hashing during key generation. This is
        /// not the same as the salt we will use during encryption. This parameter
        /// can be any string.</param>
        /// <param name="passwordIterations">Number of iterations used to hash password. More iterations are
        /// considered more secure but may take longer.</param>
        public DataCrypto(string passPhrase,
            string initializationVector = null,
            int minSaltLength = -1,
            int maxSaltLength = -1,
            int keySize = -1,
            string saltValue = null,
            int passwordIterations = 1)
        {
            // Save min salt length; set it to default if invalid value is passed.
            _minSaltLength = minSaltLength < MinAllowedSaltLength ? DefaultMinSaltLength : minSaltLength;

            // Save max salt length; set it to default if invalid value is passed.
            if (maxSaltLength < 0 || maxSaltLength > MaxAllowedSaltLength)
            {
                _maxSaltLength = DefaultMaxSaltLength;
            }
            else
            {
                _maxSaltLength = maxSaltLength;
            }

            // Set the size of cryptographic key.
            if (keySize <= 0)
            {
                keySize = DefaultKeySize;
            }

            // Get bytes of initialization vector.
            var initializationVectorBytes = initializationVector == null ? new byte[0] : Encoding.ASCII.GetBytes(initializationVector);

            // Salt used for password hashing (to generate the key, not during
            // encryption) converted to a byte array.
            var saltValueBytes = saltValue == null ? new byte[8] : Encoding.ASCII.GetBytes(saltValue);

            // Generate password, which will be used to derive the key.
            var password = new Rfc2898DeriveBytes(
                passPhrase,
                saltValueBytes,
                passwordIterations);

            // Convert key to a byte array adjusting the size from bits to bytes.
            var keyBytes = password.GetBytes(keySize / 8);

            // Initialize Rijndael key object.
            var symmetricKey = new RijndaelManaged
            {
                // If we do not have initialization vector, we cannot use the CBC mode.
                // The only alternative is the ECB mode (which is not as good).
                Mode = initializationVectorBytes.Length == 0 ? CipherMode.ECB : CipherMode.CBC
            };

            // Create encryptor and decryptor, which we will use for cryptographic
            // operations.
            _encryptor = symmetricKey.CreateEncryptor(keyBytes, initializationVectorBytes);
            _decryptor = symmetricKey.CreateDecryptor(keyBytes, initializationVectorBytes);
        }

        /// <summary>
        /// Encrypts a string value generating a base64-encoded string.
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted.</param>
        /// <returns>
        /// Cipher text formatted as a base64-encoded string.
        /// </returns>
        public string Encrypt(string plainText)
        {
            return Encrypt(Encoding.UTF8.GetBytes(plainText));
        }

        /// <summary>
        /// Encrypts a byte array generating a base64-encoded string.
        /// </summary>
        /// <param name="plainTextBytes">Plain text bytes to be encrypted.</param>
        /// <returns>
        /// Cipher text formatted as a base64-encoded string.
        /// </returns>
        public string Encrypt(byte[] plainTextBytes)
        {
            return Convert.ToBase64String(EncryptToBytes(plainTextBytes));
        }

        /// <summary>
        /// Encrypts a string value generating a byte array of cipher text.
        /// </summary>
        /// <param name="plainText">Plain text string to be encrypted.</param>
        /// <returns>
        /// Cipher text formatted as a byte array.
        /// </returns>
        public byte[] EncryptToBytes(string plainText)
        {
            return EncryptToBytes(Encoding.UTF8.GetBytes(plainText));
        }

        /// <summary>
        /// Encrypts a byte array generating a byte array of cipher text.
        /// </summary>
        /// <param name="plainTextBytes">Plain text bytes to be encrypted.</param>
        /// <returns>
        /// Cipher text formatted as a byte array.
        /// </returns>
        public byte[] EncryptToBytes(byte[] plainTextBytes)
        {
            // Add salt at the beginning of the plain text bytes (if needed).
            var plainTextBytesWithSalt = AddSalt(plainTextBytes);

            // Encryption will be performed using memory stream.
            using (var memoryStream = new MemoryStream())
            {
                // Let's make cryptographic operations thread-safe.
                lock (this)
                {
                    // To perform encryption, we must use the Write mode.
                    using (var cryptoStream = new CryptoStream(memoryStream, _encryptor, CryptoStreamMode.Write))
                    {
                        // Start encrypting data.
                        cryptoStream.Write(plainTextBytesWithSalt, 0, plainTextBytesWithSalt.Length);

                        // Finish the encryption operation.
                        cryptoStream.FlushFinalBlock();

                        // Move encrypted data from memory into a byte array.
                        var cipherTextBytes = memoryStream.ToArray();

                        // Return encrypted data.
                        return cipherTextBytes;
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts a base64-encoded cipher text value generating a string result.
        /// </summary>
        /// <param name="encryptedText">Base64-encoded cipher text string to be decrypted.</param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        public string Decrypt(string encryptedText)
        {
            return Decrypt(Convert.FromBase64String(encryptedText));
        }

        /// <summary>
        /// Decrypts a byte array containing cipher text value and generates a
        /// string result.
        /// </summary>
        /// <param name="encryptedTextBytes">Byte array containing encrypted data.</param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        public string Decrypt(byte[] encryptedTextBytes)
        {
            return Encoding.UTF8.GetString(DecryptToBytes(encryptedTextBytes));
        }

        /// <summary>
        /// Decrypts a base64-encoded cipher text value and generates a byte array
        /// of plain text data.
        /// </summary>
        /// <param name="encryptedText">Base64-encoded cipher text string to be decrypted.</param>
        /// <returns>
        /// Byte array containing decrypted value.
        /// </returns>
        public byte[] DecryptToBytes(string encryptedText)
        {
            return DecryptToBytes(Convert.FromBase64String(encryptedText));
        }

        /// <summary>
        /// Decrypts a base64-encoded cipher text value and generates a byte array
        /// of plain text data.
        /// </summary>
        /// <param name="cipherTextBytes">Byte array containing encrypted data.</param>
        /// <returns>
        /// Byte array containing decrypted value.
        /// </returns>
        public byte[] DecryptToBytes(byte[] cipherTextBytes)
        {
            using (var memoryStream = new MemoryStream(cipherTextBytes))
            {
                // Since we do not know how big decrypted value will be, use the same
                // size as cipher text. Cipher text is always longer than plain text
                // (in block cipher encryption), so we will just use the number of
                // decrypted data byte after we know how big it is.
                var decryptedBytes = new byte[cipherTextBytes.Length];

                // Let's make cryptographic operations thread-safe.
                int decryptedByteCount;

                lock (this)
                {
                    // To perform decryption, we must use the Read mode.
                    using (var cryptoStream = new CryptoStream(memoryStream, _decryptor, CryptoStreamMode.Read))
                    {
                        // Decrypting data and get the count of plain text bytes.
                        decryptedByteCount = cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    }
                }

                var saltLength = 0;

                // If we are using salt, get its length from the first 4 bytes of plain
                // text data.
                if (_maxSaltLength > 0 && _maxSaltLength >= _minSaltLength)
                {
                    saltLength = (decryptedBytes[0] & 0x03) |
                                 (decryptedBytes[1] & 0x0c) |
                                 (decryptedBytes[2] & 0x30) |
                                 (decryptedBytes[3] & 0xc0);
                }

                // Allocate the byte array to hold the original plain text (without salt).
                var plainTextBytes = new byte[decryptedByteCount - saltLength];

                // Copy original plain text discarding the salt value if needed.
                Array.Copy(decryptedBytes, saltLength, plainTextBytes,
                    0, decryptedByteCount - saltLength);

                // Return original plain text value.
                return plainTextBytes;
            }
        }

        /// <summary>
        /// Adds an array of randomly generated bytes at the beginning of the
        /// array holding original plain text value.
        /// </summary>
        /// <param name="plainTextBytes">Byte array containing original plain text value.</param>
        /// <returns>
        /// Either original array of plain text bytes (if salt is not used) or a
        /// modified array containing a randomly generated salt added at the
        /// beginning of the plain text bytes.
        /// </returns>
        private byte[] AddSalt(byte[] plainTextBytes)
        {
            // The max salt value of 0 (zero) indicates that we should not use 
            // salt. Also do not use salt if the max salt value is smaller than
            // the min value.
            if (_maxSaltLength == 0 || _maxSaltLength < _minSaltLength)
                return plainTextBytes;

            // Generate the salt.
            var saltBytes = GenerateSalt();

            // Allocate array which will hold salt and plain text bytes.
            var plainTextBytesWithSalt = new byte[plainTextBytes.Length +
                                                     saltBytes.Length];
            // First, copy salt bytes.
            Array.Copy(saltBytes, plainTextBytesWithSalt, saltBytes.Length);

            // Append plain text bytes to the salt value.
            Array.Copy(plainTextBytes, 0,
                plainTextBytesWithSalt, saltBytes.Length,
                plainTextBytes.Length);

            return plainTextBytesWithSalt;
        }

        /// <summary>
        /// Generates an array holding cryptographically strong bytes.
        /// </summary>
        /// <returns>
        /// Array of randomly generated bytes.
        /// </returns>
        /// <remarks>
        /// Salt size will be defined at random or exactly as specified by the
        /// minSlatLen and maxSaltLen parameters passed to the object constructor.
        /// The first four bytes of the salt array will contain the salt length
        /// split into four two-bit pieces.
        /// </remarks>
        private byte[] GenerateSalt()
        {
            // If min and max salt values are the same, it should not be random.
            var saltLength = _minSaltLength == _maxSaltLength ? _minSaltLength : GenerateRandomNumber(_minSaltLength, _maxSaltLength);

            // Allocate byte array to hold our salt.
            var salt = new byte[saltLength];

            // Populate salt with cryptographically strong bytes.
            var randomizer = new RNGCryptoServiceProvider();

            randomizer.GetNonZeroBytes(salt);

            // Split salt length (always one byte) into four two-bit pieces and
            // store these pieces in the first four bytes of the salt array.
            salt[0] = (byte)((salt[0] & 0xfc) | (saltLength & 0x03));
            salt[1] = (byte)((salt[1] & 0xf3) | (saltLength & 0x0c));
            salt[2] = (byte)((salt[2] & 0xcf) | (saltLength & 0x30));
            salt[3] = (byte)((salt[3] & 0x3f) | (saltLength & 0xc0));

            return salt;
        }

        /// <summary>
        /// Generates random integer.
        /// </summary>
        /// <param name="minValue">Min value (inclusive).</param>
        /// <param name="maxValue">Max value (inclusive).</param>
        /// <returns>
        /// Random integer value between the min and max values (inclusive).
        /// </returns>
        /// <remarks>
        /// This methods overcomes the limitations of .NET Framework's Random
        /// class, which - when initialized multiple times within a very short
        /// period of time - can generate the same "random" number.
        /// </remarks>
        private static int GenerateRandomNumber(int minValue, int maxValue)
        {
            // We will make up an integer seed from 4 bytes of this array.
            var randomBytes = new byte[4];

            // Generate 4 random bytes.
            var randomizer = new RNGCryptoServiceProvider();
            randomizer.GetBytes(randomBytes);

            // Convert four random bytes into a positive integer value.
            var seed = ((randomBytes[0] & 0x7f) << 24) |
                       (randomBytes[1] << 16) |
                       (randomBytes[2] << 8) |
                       (randomBytes[3]);

            var random = new Random(seed);

            // Calculate a random number.
            return random.Next(minValue, maxValue + 1);
        }

        public void Dispose()
        {
            _encryptor.Dispose();
            _decryptor.Dispose();
        }
    }
}
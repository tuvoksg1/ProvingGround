using System.Configuration;
using System.Xml;
using CXUtils.Extensions;
using CXUtils.Serialization;
using CXUtils.Startup;

namespace DynamicContainer
{
    public class Credential : DataXmlSerializer<Credential>, IConfigurationSectionHandler
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Decrypts the specified passphrase.
        /// </summary>
        /// <param name="passphrase">The passphrase.</param>
        /// <returns></returns>
        public static Credential Decrypt(string passphrase)
        {
            var credential = ConfigurationSectionLoader.Load<Credential>(Constants.CredentialSection);

            return Decrypt(credential, passphrase);
        }

        /// <summary>
        /// Decrypts the specified passphrase.
        /// </summary>
        /// <param name="credential">The credential.</param>
        /// <param name="passphrase">The passphrase.</param>
        /// <returns></returns>
        public static Credential Decrypt(Credential credential, string passphrase)
        {
            return new Credential
            {
                UserName = credential.UserName,
                Password = credential.Password.Decrypt(passphrase)
            };
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            var credential = DeserializeFromXml(section.OuterXml);

            return credential;
        }
    }
}

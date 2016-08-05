namespace ElasticConsole.Models
{
    /// <summary>
    /// The type of service being registered
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// For MVC, SOAP and REST Services
        /// </summary>
        WebApp,
        /// <summary>
        /// For javascript applications
        /// </summary>
        Javascript,
        /// <summary>
        /// For console applications
        /// </summary>
        Console,
        /// <summary>
        /// For desktop or mobile applications
        /// </summary>
        Native,
        /// <summary>
        /// For applications that will have access to user login credentials
        /// </summary>
        Login
    }
}
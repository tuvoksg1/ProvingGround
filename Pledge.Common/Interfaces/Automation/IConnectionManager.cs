using System.Collections.Generic;
using Pledge.Common.Models.Automation;

namespace Pledge.Common.Interfaces.Automation
{
    /// <summary>
    /// Manages functions related to automation connections
    /// </summary>
    public interface IConnectionManager
    {
        /// <summary>
        /// Gets the server connections.
        /// </summary>
        /// <returns></returns>
        List<Connection> GetServerConnections(string tenantId);
        /// <summary>
        /// Adds the server connection.
        /// </summary>
        void AddServerConnection(Connection connection, string tenantId);
        /// <summary>
        /// Updates the server connection.
        /// </summary>
        void UpdateServerConnection(Connection connection);
        /// <summary>
        /// Deletes the server connection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteServerConnection(string id);
    }
}
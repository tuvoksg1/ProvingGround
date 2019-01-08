using StackExchange.Redis;

namespace RedisCache
{
    public class JobCache
    {
        private IConnectionMultiplexer _connection;

        public JobCache(string host, int port, int timeoutInSeconds)
        {
            Connect(host, port, timeoutInSeconds);
        }

        public IDatabase Database { get; private set; }

        private void Connect(string host, int port, int timeoutInSeconds)
        {
            var config = new ConfigurationOptions { SyncTimeout = timeoutInSeconds * 1000 };

            var cacheEndPoint = $"{host}:{port}";

            config.EndPoints.Add(cacheEndPoint);

            _connection = ConnectionMultiplexer.Connect(config);

            if (_connection.IsConnected)
            {
                Database = _connection.GetDatabase(2);
            }
        }
    }
}

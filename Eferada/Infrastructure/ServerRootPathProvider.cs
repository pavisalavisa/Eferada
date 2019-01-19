namespace Eferada.Infrastructure
{
    public class ServerRootPathProvider : IServerRootPathProvider
    {
        public ServerRootPathProvider(string rootPath)
        {
            Path = rootPath;
        }

        public string Path { get; }
    }
}
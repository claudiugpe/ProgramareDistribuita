namespace Server
{
    public class Program
    {
        public const int port = 5000;

        public static void Main(string[] args)
        {
            TcpServer.Start(port);
            TcpServer.Listen();
        }
    }
}

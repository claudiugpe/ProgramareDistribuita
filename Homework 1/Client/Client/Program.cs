using System;

namespace Client
{
    class Program
    {
        public const string ServerAddress = "127.0.0.1";
        public const int Port = 5000;
        static void Main(string[] args)
        {
            Client.Start(ServerAddress, Port);
        }
    }
}

using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        public static TcpClient TcpClient { get; set; }

        public static int ServerMessageSize = 1024;

        public static void Start(string serverAddress, int port)
        {
            TcpClient = new TcpClient(serverAddress, port);

            System.Console.WriteLine("Client started");
            System.Console.WriteLine($"Connected to address {serverAddress} and port {port}");

            var message = string.Empty;

            while(message != null && !message.StartsWith("EXIT"))
            {
                System.Console.WriteLine("Write command");

                message = System.Console.ReadLine();

                var stream = TcpClient.GetStream();

                stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
                System.Console.WriteLine($"Sent: {message}");

                var serverData = new byte[ServerMessageSize];

                var response = stream.Read(serverData, 0, serverData.Length);
                var serverMessage = Encoding.ASCII.GetString(serverData, 0 ,response);

                System.Console.WriteLine($"Received {serverMessage}");
            }

            TcpClient.GetStream().Dispose();
            TcpClient.Dispose();
        }
    }
}

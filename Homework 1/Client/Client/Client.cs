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
                System.Console.WriteLine("Write VIEW_COMMANDS to view available commands.");

                message = System.Console.ReadLine();

                var stream = TcpClient.GetStream();

                stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
                System.Console.WriteLine($"Sent: {message}");

                var serverData = new byte[ServerMessageSize];

                var confirmation = stream.Read(serverData, 0, serverData.Length);
                var confirmationServerMessage = Encoding.ASCII.GetString(serverData, 0 , confirmation);

                System.Console.WriteLine($"Received {confirmationServerMessage}");
                serverData = new byte[ServerMessageSize];

                var commandResponse = stream.Read(serverData, 0, serverData.Length);
                var commandResponseMessage = Encoding.ASCII.GetString(serverData, 0, commandResponse);

                var commandResponseLines = commandResponseMessage.Split("&nbsp;");
                foreach (var line in commandResponseLines)
                {
                    System.Console.WriteLine(line);
                }
            }

            TcpClient.GetStream().Dispose();
            TcpClient.Dispose();
        }
    }
}

using Server.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class TcpServer
    {
        private static TcpListener Listener { get; set; }

        private static bool Accept { get; set; } = false;

        private const int ClientMesageSize = 1024;

        public static void Start(int port)
        {
            var address = IPAddress.Parse("127.0.0.1");
            Listener = new TcpListener(address, port);

            Listener.Start();
            Accept = true;

            System.Console.WriteLine($"Server started...listening at port {port}");
        }

        public static void Listen() {
            if(Listener != null && Accept)
            {
                while (true)
                {
                    System.Console.WriteLine("Waiting for client");
                    var clientTask = Listener.AcceptTcpClientAsync();

                    if(clientTask.Result != null)
                    {
                        System.Console.WriteLine("Client connected");

                        var client = clientTask.Result;
                        var message = string.Empty;

                        var cart = new Cart();

                        while(message != null && !message.StartsWith("EXIT"))
                        {
                            System.Console.WriteLine($"Received {message}.");

                            var clientData = new byte[ClientMesageSize];
                            client.GetStream().Read(clientData, 0, clientData.Length);

                            message = Encoding.ASCII.GetString(clientData);

                            var confirmationMessage = "MessageReceived...Wait for a response";
                            client.GetStream().Write(Encoding.ASCII.GetBytes(confirmationMessage), 0, confirmationMessage.Length);

                            var cartOperations = new CartOperations(cart);

                            var operationResult = cartOperations.ProcessCommand(message);

                            System.Console.WriteLine($"Sending back: {operationResult}.");

                            client.GetStream().Write(Encoding.ASCII.GetBytes(operationResult), 0, operationResult.Length);
                        }

                        System.Console.WriteLine("EXIT received...closing client!");
                        client.GetStream().Dispose();
                        client.Dispose();
                    }
                }
            }
        }
    }
}

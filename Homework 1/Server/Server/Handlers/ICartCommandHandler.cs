using Server.Models;

namespace Server.Handlers
{
    interface ICartCommandHandler
    {
        bool CanHandle(string command);

        string Handle(string command, string commandParam, Cart cart);
    }
}

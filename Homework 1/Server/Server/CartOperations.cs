using Server.Handlers;
using Server.Models;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class CartOperations
    {
        private List<ICartCommandHandler> Handlers { get; }

        private readonly Cart Cart;

        public CartOperations(Cart cart)
        {
            this.Handlers = new List<ICartCommandHandler>
            {
                new CashoutCommandHandler(),
                new RemoveItemCommandHandler(),
                new StartCartCommandHandler(),
                new ViewCartCommandHandler(),
                new ViewItemsCommandHandler(),
                new DefaultCartCommandHandler(),
                new AddItemCommandHandler(),
                new ViewCommandsCommandHandler()
            };
            this.Cart = cart;
        }

        public string ProcessCommand(string request)
        {
            var requestParts = request.Split(" ");

            var command = requestParts[0];
            var commandParam = string.Empty;

            if(requestParts.Length > 1)
            {
                commandParam = requestParts[1];
            }

            return this.ProcessInternal(command, commandParam, this.Cart);
        }

        private string ProcessInternal(string command, string commandParam, Cart cart)
        {
            var handler = this.Handlers.First(x => x.CanHandle(command));

            return handler.Handle(command, commandParam, cart);
        }
    }
}

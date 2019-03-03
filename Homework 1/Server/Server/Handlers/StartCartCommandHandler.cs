using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class StartCartCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new StartCartSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            cart.StartCart();
            return "Cart is now started.";
        }
    }
}

using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class CashoutCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new CashoutSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            var total = cart.Total;
            cart = new Cart();
            return $"Cart processed. You have to pay { total }.";
        }
    }
}

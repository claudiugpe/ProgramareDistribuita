using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class ViewCartCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new ViewCartSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            return cart.ToString();
        }
    }
}

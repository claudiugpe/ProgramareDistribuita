using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class DefaultCartCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new DefaultSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            return "Unknown command please try another one.";
        }
    }
}

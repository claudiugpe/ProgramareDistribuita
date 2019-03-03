using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    class ViewCommandsCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new ViewCommandsSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            return CartCommands.GetCommands();
        }
    }
}

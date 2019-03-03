using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class RemoveItemCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new RemoveItemSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            var position = 0;
            if(int.TryParse(commandParam, out position))
            {
                if (cart.Items.Count < position)
                {
                    return "Invalid item number.";
                }

                cart.RemoveItem(position);
                return "Item removed from cart";
            }

            return "Invalid item number.";
        }
    }
}

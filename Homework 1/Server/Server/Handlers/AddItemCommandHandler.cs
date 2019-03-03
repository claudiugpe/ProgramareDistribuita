using Server.Database;
using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class AddItemCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new AddItemSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            var repository = new ItemRepository();

            if (cart.AddItem(commandParam))
            {
                return "Item added to cart";
            }
            else
            {
                return "item Plu not found.";
            }

        }
    }
}

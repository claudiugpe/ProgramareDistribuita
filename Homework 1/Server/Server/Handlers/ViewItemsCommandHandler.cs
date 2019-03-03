using Server.Database;
using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public class ViewItemsCommandHandler : CartCommandHandlerBase
    {
        protected override ISpecification<string> GetSpecification()
        {
            return new ViewItemsSpecification();
        }

        protected override string HandleInternal(string command, string commandParam, Cart cart)
        {
            var repository = new ItemRepository();
            var result = string.Empty;

            repository.GetItems().ForEach(x => result = result + x.ToString() + "&nbsp;");

            return result;
        }
    }
}

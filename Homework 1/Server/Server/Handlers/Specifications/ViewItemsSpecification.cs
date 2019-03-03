using System;

namespace Server.Handlers.Specifications
{
    public class ViewItemsSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.VIEW_ITEMS);
        }
    }
}

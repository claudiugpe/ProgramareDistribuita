namespace Server.Handlers.Specifications
{
    public class DefaultSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return !model.StartsWith(CartCommands.ADD_ITEM) &&
                !model.StartsWith(CartCommands.CASHOUT) &&
                !model.StartsWith(CartCommands.REMOVE_ITEM) &&
                !model.StartsWith(CartCommands.START) &&
                !model.StartsWith(CartCommands.VIEW_CART) &&
                !model.StartsWith(CartCommands.VIEW_ITEMS) &&
                !model.StartsWith(CartCommands.VIEW_COMMANDS);
        }
    }
}

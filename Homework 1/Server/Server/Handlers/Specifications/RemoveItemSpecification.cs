namespace Server.Handlers.Specifications
{
    public class RemoveItemSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.REMOVE_ITEM);
        }
    }
}

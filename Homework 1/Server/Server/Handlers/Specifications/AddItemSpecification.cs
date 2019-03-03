namespace Server.Handlers.Specifications
{
    public class AddItemSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.ADD_ITEM);
        }
    }
}

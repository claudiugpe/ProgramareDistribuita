namespace Server.Handlers.Specifications
{
    public class ViewCartSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.VIEW_CART);
        }
    }
}

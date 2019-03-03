namespace Server.Handlers.Specifications
{
    public class StartCartSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.START);
        }
    }
}

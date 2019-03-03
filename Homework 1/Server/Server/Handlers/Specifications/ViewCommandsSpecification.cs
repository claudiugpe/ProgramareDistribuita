namespace Server.Handlers.Specifications
{
    public class ViewCommandsSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.VIEW_COMMANDS);
        }
    }
}

namespace Server.Handlers.Specifications
{
    public class CashoutSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string model)
        {
            return model.StartsWith(CartCommands.CASHOUT);
        }
    }
}

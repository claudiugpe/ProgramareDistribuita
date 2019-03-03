using Server.Handlers.Specifications;
using Server.Models;

namespace Server.Handlers
{
    public abstract class CartCommandHandlerBase : ICartCommandHandler
    {
        private readonly ISpecification<string> Specification;

        public CartCommandHandlerBase()
        {
            this.Specification = this.GetSpecification();
        }

        public bool CanHandle(string command)
        {
            return this.Specification.IsSatisfiedBy(command);
        }

        public string Handle(string command, string commandParam, Cart cart)
        {
            return this.HandleInternal(command, commandParam, cart);
        }

        protected abstract ISpecification<string> GetSpecification();

        protected abstract string HandleInternal(string command, string commandParam, Cart cart);
    }
}

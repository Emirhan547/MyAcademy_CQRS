namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers.CreationChain
{
    public abstract class OrderCreationStepBase : IOrderCreationStep
    {
        private IOrderCreationStep? _next;

        public IOrderCreationStep SetNext(IOrderCreationStep next)
        {
            _next = next;
            return next;
        }

        public async Task<bool> ExecuteAsync(OrderCreationContext context, CancellationToken cancellationToken)
        {
            var ok = await ProcessAsync(context, cancellationToken);
            if (!ok)
            {
                return false;
            }

            if (_next is null)
            {
                return true;
            }

            return await _next.ExecuteAsync(context, cancellationToken);
        }

        protected abstract Task<bool> ProcessAsync(OrderCreationContext context, CancellationToken cancellationToken);
    }
}
namespace LisFacadeApiBackend.Facade.Handlers
{
    public interface IHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
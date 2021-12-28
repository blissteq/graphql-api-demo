namespace ZA365Solutions.Platform.Messaging
{
    using System;
    using System.Threading.Tasks;

    public interface ICommandHandler<Td, T>
     where Td : ICommandData
     where T : ICommand<Td>
    {
        string HandlerName { get; }

        Task HandleAsync(T command);
    }
}


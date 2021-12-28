namespace ZA365Solutions.Platform.Messaging
{
    using System.Threading.Tasks;

    public interface ICommandBus
    {
        Task Publish<Td, T>(ICommand<Td> command)
          where Td : ICommandData
          where T : ICommand<Td>;

        Task Subscribe<Td, T, H>(H handler)
          where Td : ICommandData
          where T : ICommand<Td>
          where H : ICommandHandler<Td, T>;
    }

}


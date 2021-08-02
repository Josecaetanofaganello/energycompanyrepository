using EnergyCompanyConsoleApplication.Domain.Commands;

namespace EnergyCompanyConsoleApplication.Shared.Handlers
{
    interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}

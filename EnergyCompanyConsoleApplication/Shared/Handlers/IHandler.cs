using EnergyCompanyConsoleApplication.Domain.Commands;

namespace EnergyCompanyConsoleApplication.Shared.Handlers
{
    interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}

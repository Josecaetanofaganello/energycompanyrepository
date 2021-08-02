namespace EnergyCompanyConsoleApplication.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public string Message { get;  set; }
        public bool Success { get;  set; }
        public object Data { get;  set; }
    }
}

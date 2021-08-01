using EnergyCompanyConsoleApplication.Domain.Commands;
using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyCompanyConsoleApplication.Shared.Handlers
{
    public class EndpointCommandHandler : ICommandHandler<ManageEndpointCommand>
    {
        private readonly ManageEndpointCommand _endpoint;
        private readonly IEndpointCacheRepository _cache;
        private readonly ECommandType _typeCommand;


        public EndpointCommandHandler(ManageEndpointCommand endPoint, IEndpointCacheRepository cache, ECommandType typeCommand)
        {
            _endpoint = endPoint;
            _cache = cache;
            _typeCommand = typeCommand;
        }
        public ICommandResult Handle(ManageEndpointCommand command)
        {

            if (ECommandType.Insert == _typeCommand)
            {
                Console.Clear();
                Console.WriteLine("Insert SerialNumber:");
                _endpoint.SerialNumber = Console.ReadLine();

               var findEndpoint = _cache.Find(_endpoint.SerialNumber);
                if (findEndpoint != null)
                {
                    return new CommandResult(false, $" {_endpoint.SerialNumber} Already exists!", new { persistence = "no" });
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Insert MeterModelId");

                    foreach (var i in Enum.GetValues(typeof(EMeterModel)))
                    {
                        Console.WriteLine($"{((int)i)} -  {i}");
                    }
                    if (int.TryParse(Console.ReadLine(), out int model))
                    {
                        _endpoint.MeterModelId = (EMeterModel)model;
                    }
                    else
                    {
                        Console.WriteLine("Insert a valid number");
                    }

                    Console.Clear();
                    Console.WriteLine("Insert Switch State");

                    foreach (var i in Enum.GetValues(typeof(ESwitchState)))
                    {
                        Console.WriteLine($"{((int)i)} -  {i}");
                    }
                    if (int.TryParse(Console.ReadLine(), out int switchState))
                    {
                        _endpoint.SwitchState = (ESwitchState)switchState;
                    }
                    else
                    {
                        Console.WriteLine("Insert a valid number");
                    }

                    _cache.insert(new Endpoint { FirmwareVersion = _endpoint.FirmwareVersion, MeterModelId = _endpoint.MeterModelId, MeterNumber = _endpoint.MeterNumber, SerialNumber = _endpoint.SerialNumber, SwitchState = _endpoint.SwitchState });
                    return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully inserted", new { persistence = "ok" });
                }
            }

            if (ECommandType.Edit == _typeCommand)
            {
                Console.Clear();
                Console.WriteLine("Enter an Endpoint Serial Number:");
                var findEndpoint = _cache.Find(Console.ReadLine());
                if(findEndpoint != null)
                {
                    foreach (var i in Enum.GetValues(typeof(ESwitchState)))
                    {
                        Console.WriteLine($"{((int)i)} -  {i}");
                    }
                    if (int.TryParse(Console.ReadLine(), out int switchState))
                    {
                        _endpoint.SwitchState = (ESwitchState)switchState;
                    }
                    else
                    {
                        Console.WriteLine("Insert a valid number state");
                    }
                    return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully edited", new { persistence = "ok" });
                }
                else
                {
                    return new CommandResult(false, $" {_endpoint.SerialNumber} Endpoint not found!", new { persistence = "no" });
                }
            }

            if (ECommandType.Delete == _typeCommand)
            {

                return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully edited", new { persistence = "ok" });
            }
            if (ECommandType.List == _typeCommand)
            {
                Console.Clear();
                foreach(var item in _cache.ListAll())
                {
                    Console.WriteLine($"Serial Number    :{item.SerialNumber}");
                    Console.WriteLine($"Meter Model Id   :{item.MeterModelId}");
                    Console.WriteLine($"Firmware Version :{item.FirmwareVersion}");
                    Console.WriteLine($"Meter Number     :{item.MeterNumber}");
                    Console.WriteLine($"Switch State     :{item.SwitchState}");
                    Console.WriteLine("_________________________________________");
                }
                Console.WriteLine("\r\n Please press any key to continue...");
                Console.ReadKey();

                return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully Listed {_cache.ListAll().Count()}", new { persistence = "no" });
            }

            if (ECommandType.Find == _typeCommand)
            {

                return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully edited", new { persistence = "ok" });
            }
            else
            {
                return new CommandResult(true, $" {_endpoint.SerialNumber} Successfully inserted", new { persistence = "ok" });
            }
        }
    }
}

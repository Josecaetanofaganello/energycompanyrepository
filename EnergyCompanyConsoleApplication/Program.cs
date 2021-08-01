using EnergyCompanyConsoleApplication.Domain.Commands;
using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using EnergyCompanyConsoleApplication.Infrastructure.Cache;
using EnergyCompanyConsoleApplication.Shared.Handlers;
using System;

namespace EnergyCompanyConsoleApplication
{
    public static class Program
    {
        public static void Main(string[] args) 
        {
            
            bool exit = false;
            IEndpointCacheRepository _cache = new EndpointCacheRepository();
            while (!exit)
            {
                Console.WriteLine("Please enter a number to choose your option:");
                Console.WriteLine("1) - Insert a new endpoint");
                Console.WriteLine("2) - Edit an existing endpoint ");
                Console.WriteLine("3) - Delete an existing endpoint");
                Console.WriteLine("4) - List all endpoints");
                Console.WriteLine("5) - Find a endpoint by \"Endpoint Serial Number\"");
                Console.WriteLine("6) - Exit");

                var input = Console.ReadLine();
                if (int.TryParse(input, out var _input) && _input > 0 && _input <= 6)
                {
                    bool loop = true;

                    if (_input == 1)
                    {
                        string serialNumber = "";
                        EMeterModel meterModelid = (EMeterModel)15;
                        int meterNumber;
                        string firmwareVersion;
                        ESwitchState switchState;
                        while (loop)
                        {
                            Console.WriteLine("Insert SerialNumber:");
                            serialNumber = Console.ReadLine();
                            Console.WriteLine("Insert MeterModelId");


                            foreach (var i in Enum.GetValues(typeof(EMeterModel)))
                            {
                                Console.WriteLine($"{((int)i)} -  {i}");
                            }
                            if (int.TryParse(Console.ReadLine(), out int model))
                            {
                                meterModelid = (EMeterModel)model;
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Insert a valid numer");
                            }

                        }
                        
                        var cmd = new InsertEndpointCommand ("", meterModelid, 1, serialNumber,ESwitchState.Armed);
                        _cache.insert(new Endpoint {FirmwareVersion = "",MeterModelId = meterModelid,MeterNumber = 1, SerialNumber =serialNumber,SwitchState= ESwitchState.Armed });
                        var command = new InsertEndpointCommandHandler(cmd, _cache);
                        var result = command.Handle(cmd);
                        Console.WriteLine();

                    }
                    if (_input == 6)
                    {
                        Console.WriteLine("Exiting..");
                        exit = true;
                        System.Environment.Exit(-1);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Option, please choose a number between 1 and 6");
                }
            }
        }
    }
}

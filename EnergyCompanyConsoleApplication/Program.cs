using EnergyCompanyConsoleApplication.Domain.Commands;
using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using EnergyCompanyConsoleApplication.Infrastructure.Cache;
using EnergyCompanyConsoleApplication.Shared.Handlers;
using System;
using System.Collections.Generic;

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
                LoadMenu();
            }

            void LoadMenu()
            {
                List<string> menuList = new List<string>();
                menuList.Add("Please enter a number to choose your option:");
                menuList.Add("1) - Insert a new endpoint");
                menuList.Add("2) - Edit an existing endpoint ");
                menuList.Add("3) - Delete an existing endpoint");
                menuList.Add("4) - List all endpoints");
                menuList.Add("5) - Find a endpoint by \"Endpoint Serial Number\"");
                menuList.Add("6) - Exit");

                menuList.ForEach(x => Console.WriteLine(x));

                ReadInput(Console.ReadLine());
            }

            void ReadInput(string input)
            {
                if (int.TryParse(input, out var _input) && _input > 0 && _input <= 6)
                {
                    Console.Clear();
                    LoadCommand(_input);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option, please choose a number between 1 and 6");
                }
            }

            void LoadCommand(int _input)
            {
                if (_input == 6)
                {
                    Console.WriteLine($"Press 1 to Confirm and Exit");
                    if (int.TryParse(Console.ReadLine(), out int _option) && _option == 1)
                    {
                        Console.WriteLine("Exiting..");
                        exit = true;
                        System.Environment.Exit(-1);
                    }
                    else
                    {
                        exit = false;
                    }
                }
                else
                {
                    ComandInsert((ECommandType)_input);
                }
            }

            void ComandInsert(ECommandType CommandType)
            {
                ManageEndpointCommand cmd = new ManageEndpointCommand();
                var command = new EndpointCommandHandler(cmd, _cache, CommandType);
                var result = command.Handle(cmd);

                Console.WriteLine(result.Message + "\r\n");
            }
        }
    }
}

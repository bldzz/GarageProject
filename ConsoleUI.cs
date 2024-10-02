using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ConsoleUI : IUI
    {
        private IHandler handler;

        public ConsoleUI(IHandler handler)
        {
            this.handler = handler;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Create new garage\n2. Park vehicle\n3. Remove vehicle\n4. List all vehicles\n5. List vehicle types\n6. Search vehicle\n0. Exit");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        CreateGarage();
                        break;
                    case "2":
                        ParkVehicle();
                        break;
                    case "3":
                        RemoveVehicle();
                        break;
                    case "4":
                        handler.ListAllVehicles();
                        break;
                    case "5":
                        handler.ListVehicleTypes();
                        break;
                    case "6":
                        SearchVehicle();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void CreateGarage()
        {
            Console.WriteLine("Enter capacity for the garage:");
            if (int.TryParse(Console.ReadLine(), out int capacity))
            {
                handler.CreateGarage(capacity);
            }
            else
            {
                Console.WriteLine("Invalid capacity.");
            }
        }

        //private void ParkVehicle()
        //{
        //    // Park different types of vehicles based on user input
        //    Console.WriteLine("Enter vehicle type (Car, Motorcycle, Airplane, Bus, Boat):");
        //    string type = Console.ReadLine()?.ToLower() ?? string.Empty;
        //    IVehicle vehicle = null!;

        //    switch (type)
        //    {
        //        case "car":
        //            vehicle = new Car("ABC123", "Red", 4, "Diesel");
        //            break;
        //        case "motorcycle":
        //            vehicle = new Motorcycle("DEF456", "Blue", 2, 650);
        //            break;
        //        case "airplane":
        //            vehicle = new Airplane("GHI789", "White", 3, 2);
        //            break;
        //        case "bus":
        //            vehicle = new Bus("JKL012", "Yellow", 6, 50);
        //            break;
        //        case "boat":
        //            vehicle = new Boat("MNO345", "Black", 0, 25);
        //            break;
        //        default:
        //            Console.WriteLine("Invalid vehicle type.");
        //            return;
        //    }

        //    handler.ParkVehicle(vehicle);
        //}




        // Method to park a vehicle
        private void ParkVehicle()
        {
            // Check if a garage has been created
            if (!handler.IsGarageCreated())
            {
                Console.WriteLine("No garage exists. Please create a garage first.");
                Console.WriteLine("Enter the capacity for the new garage:");
                if (int.TryParse(Console.ReadLine(), out int capacity))
                {
                    handler.CreateGarage(capacity);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }
            }

            // Proceed with parking the vehicle after the garage is created
            Console.WriteLine("Enter the type of vehicle (Car, Motorcycle, Airplane, Bus, Boat):");
            string type = Console.ReadLine()?.ToLower();

            // Registration number validation and formatting
            Console.WriteLine("Enter the registration number:");
            string registrationNumber = Console.ReadLine();
            try
            {
                // Validate and format the registration number
                registrationNumber = RegistrationNumberValidator.FormatRegistrationNumber(registrationNumber);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return; // Exit if the registration number is invalid
            }

            // Get vehicle details

            // List of valid colors
            string[] validColors = { "red", "blue", "green", "black", "white", "yellow", "gray", "purple", "orange" };

            string color;

            // Loop to keep asking for a valid color until a correct one is entered
            do
            {
                Console.WriteLine("Enter the color: ");
                color = Console.ReadLine()?.ToLower(); // Convert input to lowercase for easier comparison

                if (!validColors.Contains(color))
                {
                    Console.WriteLine("Invalid color! Please enter a valid color (e.g., Red, Blue, Green, Black, White, etc.).");
                }
            } while (!validColors.Contains(color)); // Keep looping until valid color is provided




            Console.WriteLine("Enter the number of wheels:");
            if (!int.TryParse(Console.ReadLine(), out int numberOfWheels))
            {
                Console.WriteLine("Invalid number of wheels.");
                return;
            }

            IVehicle vehicle = null;

            // Based on vehicle type, ask for additional properties and create the vehicle
            switch (type)
            {

                case "car":
                    string fuelType;

                    // Loop to keep asking for a valid input until a correct fuel type is entered
                    do
                    {
                        Console.WriteLine("Enter the fuel type (Gasoline/Diesel):");
                        fuelType = Console.ReadLine()?.ToLower(); // Convert input to lowercase for easier comparison

                        if (fuelType != "gasoline" && fuelType != "diesel")
                        {
                            Console.WriteLine("Invalid fuel type! Please enter either 'Gasoline' or 'Diesel'.");
                        }
                    } while (fuelType != "gasoline" && fuelType != "diesel"); // Keep looping until valid input is provided

                    // Proceed with creating the car once a valid fuel type is provided
                    vehicle = new Car(registrationNumber, color, numberOfWheels, fuelType);
                    break;

                case "motorcycle":
                    Console.WriteLine("Enter the cylinder volume:");
                    if (int.TryParse(Console.ReadLine(), out int cylinderVolume))
                    {
                        vehicle = new Motorcycle(registrationNumber, color, numberOfWheels, cylinderVolume);
                    }
                    else
                    {
                        Console.WriteLine("Invalid cylinder volume.");
                        return;
                    }
                    break;
                case "airplane":
                    Console.WriteLine("Enter the number of engines:");
                    if (int.TryParse(Console.ReadLine(), out int numberOfEngines))
                    {
                        vehicle = new Airplane(registrationNumber, color, numberOfWheels, numberOfEngines);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of engines.");
                        return;
                    }
                    break;
                case "bus":
                    Console.WriteLine("Enter the number of seats:");
                    if (int.TryParse(Console.ReadLine(), out int numberOfSeats))
                    {
                        vehicle = new Bus(registrationNumber, color, numberOfWheels, numberOfSeats);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of seats.");
                        return;
                    }
                    break;
                case "boat":
                    Console.WriteLine("Enter the length of the boat:");
                    if (double.TryParse(Console.ReadLine(), out double length))
                    {
                        vehicle = new Boat(registrationNumber, color, numberOfWheels, length);
                    }
                    else
                    {
                        Console.WriteLine("Invalid boat length.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type.");
                    return;
            }

            // Attempt to park the vehicle
            if (vehicle != null)
            {
                handler.ParkVehicle(vehicle);
                Console.WriteLine($"{type} parked successfully!\n");
            }
        }





        private void RemoveVehicle()
        {
            Console.WriteLine("Enter registration number to remove:");
            string regNo = Console.ReadLine() ?? string.Empty;
            handler.RemoveVehicle(regNo);
        }

        private void SearchVehicle()
        {

            if (!handler.IsGarageCreated())
            {
                Console.WriteLine("No garage exists. Please create a garage first!\n");
            }
            else { 
            
                    Console.WriteLine("Enter color to search:");
                    string color = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter number of wheels to search (optional):");
                if (int.TryParse(Console.ReadLine(), out int wheels))
                {
                    var result = handler.SearchVehicles(color, wheels);
                    foreach (var vehicle in result)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                else
                {
                    var result = handler.SearchVehicles(color);
                    foreach (var vehicle in result)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
            
            }

        }
    }

}


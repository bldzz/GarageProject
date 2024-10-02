using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
  
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> garage;

        // Method to create a new garage with the given capacity
        public void CreateGarage(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
            Console.WriteLine($"Garage created with a capacity of {capacity} vehicles.");
        }

        // Method to park a vehicle into the garage
        //public void ParkVehicle(IVehicle vehicle)
        //{
        //    if (garage == null)
        //    {
        //        Console.WriteLine("Garage not created yet. Please create a garage first.");
        //        return;
        //    }

        //    if (garage.Park(vehicle))
        //    {
        //        Console.WriteLine($"Successfully parked {vehicle.GetType().Name} with registration number {vehicle.RegistrationNumber}.");
        //    }
        //}

        public void ParkVehicle(IVehicle vehicle)
        {
            if (garage == null)
            {
                Console.WriteLine("No garage has been created yet.");
                return;
            }

            if (!garage.Park(vehicle))
            {
                Console.WriteLine("The garage is full. Unable to park the vehicle.");
            }
            else
            {
                Console.WriteLine($"Vehicle {vehicle.RegistrationNumber} parked.");
            }
        }

        // Method to remove a vehicle from the garage using its registration number
        public void RemoveVehicle(string registrationNumber)
        {
            if (garage == null)
            {
                Console.WriteLine("Garage not created yet. Please create a garage first.");
                return;
            }

            if (garage.Remove(registrationNumber))
            {
                Console.WriteLine($"Vehicle with registration number {registrationNumber} removed from the garage.");
            }
            else
            {
                Console.WriteLine($"Vehicle with registration number {registrationNumber} not found.");
            }
        }

        // Method to search vehicles by color and number of wheels
        public IVehicle[] SearchVehicles(string color, int? numberOfWheels = null)
        {
            if (garage == null)
            {
                Console.WriteLine("Garage not created yet. Please create a garage first.");
                return Array.Empty<IVehicle>();
            }

            var result = garage.Where(v =>
                v.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                (!numberOfWheels.HasValue || v.NumberOfWheels == numberOfWheels)).ToArray();

            return result;
        }

        // Method to list all parked vehicles
        public void ListAllVehicles()
        {
            if (garage == null)
            {
                Console.WriteLine("Garage not created yet. Please create a garage first.");
                return;
            }

            Console.WriteLine("Vehicles currently in the garage:");
            foreach (var vehicle in garage)
            {
                Console.WriteLine(vehicle);
            }
        }

        // Method to list vehicle types and the count of each type
        public void ListVehicleTypes()
        {
            if (garage == null)
            {
                Console.WriteLine("Garage not created yet. Please create a garage first.");
                return;
            }

            var groups = garage.GroupBy(v => v.GetType().Name);
            Console.WriteLine("Vehicle types in the garage:");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
        }
    }
}











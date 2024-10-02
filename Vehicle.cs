using Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public abstract class Vehicle : IVehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }
    public int NumberOfWheels { get; }

    protected Vehicle(string registrationNumber, string color, int numberOfWheels)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        NumberOfWheels = numberOfWheels;
    }

    public override string ToString()
    {
        return $"{GetType().Name} - RegNo: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";
    }
}
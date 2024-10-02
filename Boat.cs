using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Boat : Vehicle
{
    public double Length { get; }

    public Boat(string registrationNumber, string color, int numberOfWheels, double length)
        : base(registrationNumber, color, numberOfWheels)
    {
        Length = length;
    }

    public override string ToString()
    {
        return base.ToString() + $", Length: {Length} meters";
    }
}


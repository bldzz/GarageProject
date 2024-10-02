using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Bus : Vehicle
{
    public int NumberOfSeats { get; }

    public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats)
        : base(registrationNumber, color, numberOfWheels)
    {
        NumberOfSeats = numberOfSeats;
    }

    public override string ToString()
    {
        return base.ToString() + $", Seats: {NumberOfSeats}";
    }
}

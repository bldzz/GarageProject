using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Motorcycle : Vehicle
{
    public int CylinderVolume { get; }

    public Motorcycle(string registrationNumber, string color, int numberOfWheels, int cylinderVolume)
        : base(registrationNumber, color, numberOfWheels)
    {
        CylinderVolume = cylinderVolume;
    }

    public override string ToString()
    {
        return base.ToString() + $", Cylinder Volume: {CylinderVolume}cc";
    }
}


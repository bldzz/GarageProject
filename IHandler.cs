using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IHandler
    {
        void CreateGarage(int capacity);
        bool IsGarageCreated();
        void ParkVehicle(IVehicle vehicle);
        void RemoveVehicle(string registrationNumber);
        IVehicle[] SearchVehicles(string color, int? numberOfWheels = null);
        void ListAllVehicles();
        void ListVehicleTypes();
    }

}



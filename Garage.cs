using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T[] vehicles;
        private int capacity;
        private int count;

        public Garage(int capacity)
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
            count = 0;
        }

        // Park a vehicle in the garage
        public bool Park(T vehicle)
        {
            if (count >= capacity) return false;

            vehicles[count++] = vehicle;
            return true;
        }

        // Remove a vehicle based on its registration number
        public bool Remove(string registrationNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = vehicles[--count]; // Replace with last element
                    vehicles[count] = default(T);    // Clear last slot
                    return true;
                }
            }
            return false;
        }

        // Implement IEnumerable<T> for LINQ support
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}



//public class Garage<T> where T : IVehicle
//{
//    private T[] vehicles;
//    private int capacity;
//    private int count;

//    public Garage(int capacity)
//    {
//        this.capacity = capacity;
//        vehicles = new T[capacity];
//        count = 0;
//    }

//    public bool Park(T vehicle)
//    {
//        if (count >= capacity)
//        {
//            Console.WriteLine("Garage is full.");
//            return false;
//        }
//        vehicles[count] = vehicle;
//        count++;
//        Console.WriteLine($"{vehicle.GetType().Name} parked.");
//        return true;
//    }

//    public bool Remove(string registrationNumber)
//    {
//        for (int i = 0; i < count; i++)
//        {
//            if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
//            {
//                vehicles[i] = vehicles[count - 1]; // Replace with the last vehicle
//                vehicles[count - 1] = default!;
//                count--;
//                Console.WriteLine($"{registrationNumber} removed.");
//                return true;
//            }
//        }
//        Console.WriteLine($"{registrationNumber} not found.");
//        return false;
//    }

//    public IEnumerator<T> GetEnumerator()
//    {
//        for (int i = 0; i < count; i++)
//        {
//            yield return vehicles[i];
//        }
//    }

//    //internal IEnumerable<object> GroupBy(Func<object, object> value)
//    //{
//    //    throw new NotImplementedException();
//    //}

//    //internal object Where(Func<object, bool> value)
//    //{
//    //    throw new NotImplementedException();
//    //}
//}




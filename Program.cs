using System.Reflection.Metadata;
using System;

namespace Garage
{
    public class Program
    {
        public static void Main()
        {
            IHandler handler = new GarageHandler();
            IUI ui = new ConsoleUI(handler);
            ui.Start();
        }
    }
}

using Domain;
using System;

namespace CarShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Car c1 = new Car("234");
            c1.SetCarName(null);
            Console.WriteLine(c1.GetCarName());
        }
    }
}

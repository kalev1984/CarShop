using Domain;
using System;
using System.Collections.Generic;

namespace CarShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car("Toyota"),
                new Car("Opel"),
            };
            
            List<Model> models = new List<Model>
            {
                new Model(cars[0] ,"Corolla", 2013, 20000),
                new Model(cars[0], "Rav4", 2009, 14000),
                new Model(cars[0], "Avensis", 2013, 24000),
                new Model(cars[1], "Omega", 2002, 1500),
                new Model(cars[1], "Astra", 2007, 2500),
                new Model(cars[1], "Insignia", 2018, 18000)
            };

            Accessory cruiseControl = new Accessory("Cruise Control", 500);
            Accessory trolleyHook = new Accessory("Trolley Hook", 200);
            Accessory climateControl = new Accessory("Climate Control", 1000);

            foreach(var i in models)
            {
                i.AddModelAccessory(cruiseControl);
                i.AddModelAccessory(trolleyHook);
                i.AddModelAccessory(climateControl);
            }

            models[1].SetModelDiscount(20);
            models[3].SetModelDiscount(25);

            int totalCost = 0;

            foreach(var i in models)
            {
                totalCost += i.GetModelPrice();
            }

            Console.WriteLine("Currently we sell " + cars.Count + " cars and " + models.Count + " models.");
            Console.WriteLine("Total cost of cars is " + totalCost);
            Console.WriteLine("At the moment, there are 2 cars on sale:");
            Console.WriteLine(models[1].ToString());
            Console.WriteLine(models[3].ToString());
        }
    }
}

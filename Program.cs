using System.Reflection;
using System.Text;
using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string input;
            var tires = new List<Tire[]>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] tireInfo = input.Split().Select(double.Parse).ToArray();
                Tire[] currentTires = new Tire[4]
                {
                    new Tire ((int)tireInfo[0], tireInfo[1]),
                    new Tire ((int)tireInfo[2], tireInfo[3]),
                    new Tire ((int)tireInfo[4], tireInfo[5]),
                    new Tire ((int)tireInfo[6], tireInfo[7]),
                };
                tires.Add(currentTires);
            }
            var engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] engineInfo = input.Split().Select(double.Parse).ToArray();
                int horsePower = (int)engineInfo[0];
                double cubicCapacity = engineInfo[1];
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }
            var cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }
            cars = cars.Where(car => car.Year >= 2017
            && car.Engine.HorsePower > 330
            && car.Tires.Sum(tire => tire.Pressure) >= 9
            && car.Tires.Sum(tire => tire.Pressure) <= 10)
            .ToList();
            cars.ForEach(car => car.Drive(20));
            if (cars.Any())
            {
                cars.ForEach(car => PrintCar(car));
            }            
        }

        static void PrintCar(Car car)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {car.Make}");
            result.AppendLine($"Model: {car.Model}");
            result.AppendLine($"Year: {car.Year}");
            result.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
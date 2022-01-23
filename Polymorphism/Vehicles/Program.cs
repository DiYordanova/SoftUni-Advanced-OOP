using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] parts = Console.ReadLine().Split();
                string command = parts[0];
                string vehicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                try
                {
                    if (vehicleType == nameof(Car))
                    {
                        ProcessComman(car, command, parameter);
                    }

                    else if (vehicleType == nameof(Bus))
                    {
                        ProcessComman(bus, command, parameter);
                    }

                    else
                    {
                        ProcessComman(truck, command, parameter);
                    }
                }
                catch (Exception ex)
                    when(ex is InvalidOperationException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessComman(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }

            else if (command == "DriveEmpty")
            {

                ((Bus)vehicle).TurnOffAirConditioner();

                vehicle.Drive(parameter);

                ((Bus)vehicle).TurnOnAirConditioner();

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }

            else
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split();
            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double litersPerKm = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, litersPerKm, tankCapacity);
            }

            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, litersPerKm, tankCapacity);
            }

            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, litersPerKm, tankCapacity);
            }

            return vehicle;
        }
    }
}

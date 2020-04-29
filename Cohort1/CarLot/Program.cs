using System;
using System.Collections.Generic;

namespace CarLot
{
      internal class Program
      {
        public static string NameInput { get; private set; }
        public static string ListVehiclesInput { get; private set; }
        public static void Main(string[] args)
        {
            Console.WriteLine("Name");
            NameInput = Console.ReadLine();
            Console.WriteLine("A list of Vehicles.");
            ListVehiclesInput = Console.ReadLine();
            Console.WriteLine("Add a vehicle to the lot.");
            string VehiclesInput = Console.ReadLine();
            Console.WriteLine("Print the inventory of the car, including number of vehicles and details about each vehicle.");
            VehiclesInput = Console.ReadLine();

            Console.WriteLine("Type in a vehicle type.");
            Console.WriteLine("Is the car a vehicle? Yes or No");

            CarLot carLot1 = new CarLot("Mora Rentals", new List<Vehicle>());

            Vehicle Dodge = new Car("Sport", 2, "Dodge", "Charger", "$40,000", "123ABC");
            Vehicle Toyota = new Truck("Toyota", "10ft", "THEA233", "Tacoma");
            Vehicle Ford = new Car("Coupe", 30, "Ford", "Taurus", "$45,450", "ERA125");

            carLot1.AddVehicle(Dodge);
            carLot1.AddVehicle(Toyota);
            carLot1.AddVehicle(Ford);

            carLot1.PrintCarLot();
            Console.ReadLine();

            CarLot carLot2 = new CarLot("Garcia's Used Cars", new List<Vehicle>());

            Vehicle Car1 = new Car("SUV", 4, "Dodge", "Journey", "$50,000", "ERH456");
            Vehicle Car2 = new Truck("Ford", "15ft", "$60,456", "IJKL230", "F150");

            carLot2.AddVehicle(Car1);
            carLot2.AddVehicle(Car2);

            carLot2.PrintCarLot();
            Console.ReadLine();
        }

        internal class CarLot
        {
            public string name { get; set; }
            public List<Vehicle> CarList { get; set; }
            public CarLot(string iname, List<Vehicle> iCarList)
            {
                name = iname;
                CarList = iCarList;
            }

            public virtual void AddVehicle(Vehicle vehicle)
            {
                CarList.Add(vehicle);
            }

            public void PrintCarLot()
            {
                Console.WriteLine("{0}:", name);
                foreach(Vehicle vehicle in CarList)
                {
                    Console.WriteLine(vehicle.printDescription());
                }
            }
        }
    }

    internal class Truck : Vehicle
    {
        public Truck(string ilicensenumber, string imake, string imodel, string iprice) : base(ilicensenumber, imake, imodel, iprice)
        {
        }

        public Truck(string ilicensenumber, string imake, string imodel, string iprice, string v) : base(ilicensenumber, imake, imodel, iprice)
        {
        }
    }

    internal class Vehicle
    {
        public string licensenumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string price { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(string ilicensenumber, string imake, string imodel, string iprice)
        {
            licensenumber = ilicensenumber;
            make = imake;
            model = imodel;
            price = iprice;
        }

        public virtual string printDescription()
        {
            return $"ID: {licensenumber} \n{make} \n{model} \n{price}";
        }
    }

    internal class Car : Vehicle
    {
        private string v1;
        private int v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;

        private string Type { get; set; }
        private int DoorCount { get; set; }

        public Car(string IType, int v, string IMake, string IPrice, string ILicenseNumber, string IModel, string IBedSize) : base(IMake, IModel, IPrice, ILicenseNumber)
        {
            BedSize = IBedSize;
        }

        public Car(string v1, int v2, string v3, string v4, string v5, string v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

        public string BedSize { get; set; }

        public override string printDescription()
        {
            return base.printDescription();
        }
    }
}

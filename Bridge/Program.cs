using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    interface Workshop
    {
        void Work();
    }
    abstract class Vehicle
    {
        protected Workshop ServiceShop;
        protected Workshop AssemblyShop;

        protected Vehicle(Workshop serviceshop, Workshop assemblyshop)
        {
            this.ServiceShop = serviceshop;
            this.AssemblyShop = assemblyshop;
        }

        public abstract void Manufacture();
    }


    class Car : Vehicle
    {
        public Car(Workshop serviceshop, Workshop assemblyshop) : base(serviceshop, assemblyshop)
        {
            this.ServiceShop = serviceshop;
            this.AssemblyShop = assemblyshop;
        }

        public override void Manufacture()
        {
            Console.WriteLine("Car Manufacturing");
            ServiceShop.Work();
            AssemblyShop.Work();
        }

    }

    class Bike : Vehicle
    {
        public Bike(Workshop serviceshop, Workshop assemblyshop) : base(serviceshop, assemblyshop)
        {
            this.ServiceShop = serviceshop;
            this.AssemblyShop = assemblyshop;
        }

        public override void Manufacture()
        {
            Console.WriteLine("Bike Manufacturing");
            ServiceShop.Work();
            AssemblyShop.Work();
        }

    }

    class Production : Workshop
    {
        public void Work()
        {
            Console.WriteLine("Parts Production & Service");
        }
    }

    class Assembly : Workshop
    {
        public void Work()
        {
            Console.WriteLine("Vehicle Parts Assembly");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car(new Production(), new Assembly());
            car.Manufacture();
            Vehicle bike = new Bike(new Production(), new Assembly());
            bike.Manufacture();

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral
{
    public class TemplateMethod
    {
        public static void Demo()
        {
            var tesla = new TeslaBuilder("Tesla");
            var lanos = new LanosBuilder("Lanos");
            var hyundai = new HyundaiBuilder("Hyundai");

            tesla.Build();
            lanos.Build();
            hyundai.Build();
        }
    }

    public abstract class CarBuilder
    {
        private readonly string _carName;

        protected CarBuilder(string carName)
        {
            _carName = carName;
        }
        protected abstract void AddEngine();
        protected abstract void InstallChassis();
        protected abstract void AddElectronics();

        protected virtual void CollectAccessories()
        {
            Console.Write("base accessories");
        }

        protected virtual void Operation()
        {
            Console.Write($"Create car: {_carName}");
        }

        protected string GetCarName()
        {
            return _carName;
        }

        public void Build()
        {
            Operation();
            AddEngine();
            InstallChassis();
            AddElectronics();
            CollectAccessories();
            Console.WriteLine();
        }
    }

    public class TeslaBuilder : CarBuilder
    {
        public TeslaBuilder(string carName) : base(carName) { }

        protected override void Operation()
        {
            base.Operation();
            Console.WriteLine(" with special accessories");
        }

        protected override void AddEngine() => Console.WriteLine("Add electronic engine");

        protected override void InstallChassis() => Console.WriteLine($"Install {base.GetCarName()} chassis");

        protected override void AddElectronics() => Console.WriteLine($"Add special {base.GetCarName()} electronic");

        protected override void CollectAccessories()
        {
            base.CollectAccessories();
            Console.WriteLine($" + add Tesla special accessories");
        }
    }

    public class LanosBuilder : CarBuilder
    {
        public LanosBuilder(string carName) : base(carName) { }

        protected override void AddEngine() => Console.WriteLine("Add petrol engine");

        protected override void InstallChassis() => Console.WriteLine($"Install {base.GetCarName()} chassis");

        protected override void AddElectronics() => Console.WriteLine($"Add special {base.GetCarName()} electronic");

        protected override void CollectAccessories() => Console.WriteLine($"Collect {base.GetCarName()} accessories");


    }
    public class HyundaiBuilder : CarBuilder
    {
        public HyundaiBuilder(string carName) : base(carName) { }

        protected override void Operation()
        {
            base.Operation();
            Console.WriteLine(" with special accessories");
        }

        protected override void AddEngine() => Console.WriteLine("Add gas engine");

        protected override void InstallChassis() => Console.WriteLine($"Install {base.GetCarName()} chassis");

        protected override void AddElectronics() => Console.WriteLine($"Add special {base.GetCarName()} electronic");

        protected override void CollectAccessories()
        {
            base.CollectAccessories();
            Console.WriteLine($" + add panorama roof");
        }
    }
}

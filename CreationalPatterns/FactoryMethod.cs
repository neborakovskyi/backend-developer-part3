using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public interface ITransport
    {
        void Delivery();
    }

    public abstract class Transport : ITransport
    {
        private readonly string _type;
        protected Transport(string type)
        {
            _type = type;
        }
        
        public void Delivery()
        {
            Console.WriteLine($"Delivery type: {_type}");
        }
    }

    public class Truck : Transport
    {
        public Truck() : base("Land transport"){}
    }

    public class Plane : Transport
    {
        public Plane() : base("Air transport") { }
    }

    public class Ship : Transport
    {
        public Ship() : base("Sea transport") { }
    }

    public abstract class Logistic
    {
        public abstract ITransport  CreateTransport();

        public void PlanDelivery()
        {
            var transport = CreateTransport();
            transport.Delivery();
        }
    }

    public class RoadLogistic : Logistic
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }
    public class AirLogistic : Logistic
    {
        public override ITransport CreateTransport()
        {
            return new Plane();
        }
    }
    public class SeaLogistic : Logistic
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

}

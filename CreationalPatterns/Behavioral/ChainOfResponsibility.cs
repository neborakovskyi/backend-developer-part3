using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral
{
    public class Order
    {
        private string _id;

        public Order(string id) => _id = id;
        public string GetOrderId() => _id;
    }

    public interface IHandler
    {
        void Handler(Order order);
        IHandler Next(IHandler next);
    }

    public abstract class HandlerBase: IHandler
    {
        private IHandler _next;

        public virtual void Handler(Order order)
        {
            if (_next != null)
            {
                _next.Handler(order);
            }
        }

        public IHandler Next(IHandler next)
        {
            _next = next;
            return next;
        }
    }

    public class Taxi : HandlerBase
    {
        private readonly string _number;

        public Taxi(string number)
        {
            _number = number;
        }

        public override void Handler(Order order)
        {
            if (CheckIsBusy())
            {
                Console.WriteLine($"The car #{_number} is busy");
                base.Handler(order);
            }
            else
            {
                Console.WriteLine($"The car #{_number} takes order {order.GetOrderId()}");
            }
        }

        private bool CheckIsBusy()
        {
            return (new Random().Next(100)) < 85;
        }
    }

    public class Repeater : HandlerBase
    {
        private Order _order;

        public override void Handler(Order order)
        {
            if (_order == order)
            {
                Console.WriteLine("All car are busy");
            }
            else
            {
                _order = order;
            }
            base.Handler(order);
        }
    }

    public class ChainDemo
    {
        public static void Run()
        {
            var handler = new Repeater();
            handler.Next(new Taxi("101"))
                .Next(new Taxi("102"))
                .Next(new Taxi("103"))
                .Next(new Taxi("104"))
                .Next(new Taxi("105"))
                .Next(handler);

            var order = new Order("1");
            handler.Handler(order);
        }

    }
}

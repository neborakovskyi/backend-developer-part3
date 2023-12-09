using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural
{
    #region notifier

    public interface INotifier
    {
        public void Send(string message);
    }

    public class Notifier : INotifier
    {
        public void Send(string message)
        {
            Console.Write($"send message: {message}");
        }
    }

    public abstract class BaseDecorator : INotifier
    {
        private readonly INotifier _wrappee;

        protected BaseDecorator(INotifier wrappee) => _wrappee = wrappee;
        public virtual void Send(string message) => _wrappee.Send(message);
    }

    public class Sms : BaseDecorator
    {
        public Sms(INotifier wrappee) : base(wrappee) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.Write(" >> SMS");
        }
    }
    public class Facebook : BaseDecorator
    {
        public Facebook(INotifier wrappee) : base(wrappee) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.Write(" >> Facebook");
        }
    }
    public class Slack : BaseDecorator
    {
        public Slack(INotifier wrappee) : base(wrappee) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.Write(" >> Slack");
        }
    }

    public class Client
    {
        private readonly string _message;
        public Client(string message) => _message = message;
        public void Send(INotifier notifier) => notifier.Send(_message);
    }

    public class DecoratorDemo
    {
        public static void Run()
        {
            var client = new Client("Hello, World! This is Decorator.");
            var notifier = new Notifier();
            client.Send(notifier);
            Console.WriteLine();

            var sms = new Sms(notifier);
            client.Send(sms);
            Console.WriteLine();
            var fb = new Facebook(sms);
            client.Send(fb);
            Console.WriteLine();
            var slack = new Slack(fb);
            client.Send(slack);
            Console.WriteLine();
        }
    }

    #endregion

    public abstract class Pizza
    {
        public string Name { get; protected set; }

        protected Pizza(string name)
        {
            Name = name;
        }

        public abstract string GetPizzaComposition();
        public abstract decimal GetCost();

        public void GetBill()
        {
            Console.WriteLine("***********************");
            Console.WriteLine($"Pizza name: {Name}");
            Console.WriteLine($"Composition: {GetPizzaComposition()}");
            Console.WriteLine($"Price: {GetCost()} uah");
            Console.WriteLine("***********************");
            Console.WriteLine();
        }
    }

    public class Margarita : Pizza
    {
        public Margarita() : base("Маргаріта") { }

        public override string GetPizzaComposition()
        {
            return "Соус 'Томатний', сир 'Моцарела', томат";
        }

        public override decimal GetCost()
        {
            return 118.75m;
        }
    }

    public class Kids : Pizza
    {
        public Kids() : base("Дитяча") { }

        public override string GetPizzaComposition()
        {
            return "Соус томатний, сир 'Моцарелла', куряче філе(копчене), томат, кукурудза консервована";
        }

        public override decimal GetCost()
        {
            return 152m;
        }
    }

    public abstract class PizzaDecorator : Pizza
    {
        private readonly Pizza _pizza;
        protected PizzaDecorator(string name, Pizza pizza) : base(name)
        {
            _pizza = pizza;
        }
        public override string GetPizzaComposition()
        {
            return _pizza.GetPizzaComposition();
        }

        public override decimal GetCost()
        {
            return _pizza.GetCost();
        }
    }

    public class ExtraTomato : PizzaDecorator
    {
        public ExtraTomato(Pizza pizza) : base($"{pizza.Name} + томат", pizza) { }

        public override string GetPizzaComposition()
        {
            return $"{base.GetPizzaComposition()} + додатково томат";
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 30;
        }
    }

    public class ExtraCheese : PizzaDecorator
    {
        public ExtraCheese(Pizza pizza) : base($"{pizza.Name} + сир", pizza) { }

        public override string GetPizzaComposition()
        {
            return $"{base.GetPizzaComposition()} + додатково сир";
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 15;
        }
    }

    public class ExtraSausage : PizzaDecorator
    {
        public ExtraSausage(Pizza pizza) : base($"{pizza.Name} + Салямі", pizza) { }

        public override string GetPizzaComposition()
        {
            return $"{base.GetPizzaComposition()} + додатково Салямі";
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 45;
        }
    }

    public class PizzaDemo
    {
        public static void Run()
        {
            Pizza pizza = new Margarita();
            pizza.GetBill();
            pizza = new ExtraSausage(pizza);
            pizza.GetBill();
            
            Pizza kids = new Kids();
            kids.GetBill();
            kids = new ExtraSausage(new ExtraCheese(new ExtraTomato(kids)));
            kids.GetBill();
        }
    }
}

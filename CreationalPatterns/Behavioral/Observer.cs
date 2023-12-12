using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral
{
    public class Observer
    {
        public static void Demo()
        {
            var vacancies = new List<string>() {"Web Developer"};
            var jobSite = new JobSite(vacancies);

            var subscriber1 = new Subscriber("Ann", "C#");
            var subscriber2 = new Subscriber("Peter", "web");
            var subscriber3 = new Subscriber("Sanka", "Plumber");
            var subscriber4 = new Subscriber("Olik", "C#");

            jobSite.AddObserver(subscriber1);
            jobSite.AddObserver(subscriber2);
            jobSite.AddObserver(subscriber3);
            jobSite.AddObserver(subscriber4);

            jobSite.AddVacancy("C# developer");
            jobSite.AddVacancy("Web Java developer");
            jobSite.AddVacancy("Senior C# developer");
            jobSite.AddVacancy("Plumber");

            jobSite.RemoveVacancy("C# developer");
            jobSite.RemoveVacancy("Web Developer");

        }
    }
    public interface IObserver
    {
        public void HandleEvent(IEnumerable<string> vacancies);
    }

    public interface IObservable
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void NotifyObservers();
    }

    public class Subscriber : IObserver
    {
        private readonly string _name;
        private readonly string _vacancy;
        public Subscriber(string name, string vacancy)
        {
            _name = name;
            _vacancy = vacancy;
        }

        public void HandleEvent(IEnumerable<string> vacancies)
        {
            if (vacancies.Any(a => a.ToLower().Contains(_vacancy.ToLower())))
            {
                var vacanciesString = string.Join(", ", vacancies.Where(w => w.ToLower().Contains(_vacancy.ToLower())));
                Console.WriteLine($"Hello {_name}, \nWe have some changes in vacancies: {vacanciesString}\n");
            }
        }
    }

    public class JobSite : IObservable
    {
        private IList<string> _vacancies;
        private IList<IObserver> _subscribers;

        public JobSite(IList<string> vacancies)
        {
            _vacancies = vacancies;
            _subscribers = new List<IObserver>();
        }

        public void AddVacancy(string name)
        {
            Console.WriteLine($"new vacancy is added {name}");
            _vacancies.Add(name);
            var vacanciesString = string.Join(", ", _vacancies);
            Console.WriteLine($"All vacancies:\n\t{vacanciesString}");
            NotifyObservers();
        }
        public void RemoveVacancy(string name)
        {
            Console.WriteLine($"vacancy is removed {name}");
            _vacancies.Remove(name);
            var vacanciesString = string.Join(", ", _vacancies);
            Console.WriteLine($"All vacancies:\n\t{vacanciesString}");
            NotifyObservers();
        }

        public void AddObserver(IObserver observer) => _subscribers.Add(observer);

        public void RemoveObserver(IObserver observer) => _subscribers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.HandleEvent(_vacancies);
            }
        }
    }
}

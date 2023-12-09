using Patterns.Behavioral;
using Patterns.Structural;

namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChainDemo.Run();
            DecoratorDemo.Run();
            PizzaDemo.Run();
        }
    }
}
/*
The car #101 is busy
The car #102 is busy
The car #103 is busy
The car #104 is busy
The car #105 is busy
All car are busy
The car #101 is busy
The car #102 is busy
The car #103 is busy
The car #104 is busy
The car #105 takes order 1
 */

/*
send message: Hello, World! This is Decorator.
send message: Hello, World! This is Decorator. >> SMS
send message: Hello, World! This is Decorator. >> SMS >> Facebook
send message: Hello, World! This is Decorator. >> SMS >> Facebook >> Slack
 */

/*
***********************
Pizza name: Маргар?та
Composition: Соус 'Томатний', сир 'Моцарела', томат
Price: 118,75 uah
***********************

***********************
Pizza name: Маргар?та + Салям?
Composition: Соус 'Томатний', сир 'Моцарела', томат + додатково Салям?
Price: 163,75 uah
***********************

***********************
Pizza name: Дитяча
Composition: Соус томатний, сир 'Моцарелла', куряче ф?ле(копчене), томат, кукурудза консервована
Price: 152 uah
***********************

***********************
Pizza name: Дитяча + томат + сир + Салям?
Composition: Соус томатний, сир 'Моцарелла', куряче ф?ле(копчене), томат, кукурудза консервована + додатково томат + додатково сир + додатково Салям?
Price: 242 uah
***********************
 */
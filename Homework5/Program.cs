using Patterns.Behavioral;

namespace Homework5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TemplateMethod.Demo();
            Observer.Demo();
        }
    }
}
/*
Create car: Tesla with special accessories
Add electronic engine
Install Tesla chassis
Add special Tesla electronic
base accessories + add Tesla special accessories

Create car: LanosAdd petrol engine
Install Lanos chassis
Add special Lanos electronic
Collect Lanos accessories

Create car: Hyundai with special accessories
Add gas engine
Install Hyundai chassis
Add special Hyundai electronic
base accessories + add panorama roof
 */

/*
new vacancy is added C# developer
All vacancies:
        Web Developer, C# developer
Hello Ann,
We have some changes in vacancies: C# developer

Hello Peter,
We have some changes in vacancies: Web Developer

Hello Olik,
We have some changes in vacancies: C# developer

new vacancy is added Web Java developer
All vacancies:
        Web Developer, C# developer, Web Java developer
Hello Ann,
We have some changes in vacancies: C# developer

Hello Peter,
We have some changes in vacancies: Web Developer, Web Java developer

Hello Olik,
We have some changes in vacancies: C# developer

new vacancy is added Senior C# developer
All vacancies:
        Web Developer, C# developer, Web Java developer, Senior C# developer
Hello Ann,
We have some changes in vacancies: C# developer, Senior C# developer

Hello Peter,
We have some changes in vacancies: Web Developer, Web Java developer

Hello Olik,
We have some changes in vacancies: C# developer, Senior C# developer

new vacancy is added Plumber
All vacancies:
        Web Developer, C# developer, Web Java developer, Senior C# developer, Plumber
Hello Ann,
We have some changes in vacancies: C# developer, Senior C# developer

Hello Peter,
We have some changes in vacancies: Web Developer, Web Java developer

Hello Sanka,
We have some changes in vacancies: Plumber

Hello Olik,
We have some changes in vacancies: C# developer, Senior C# developer

vacancy is removed C# developer
All vacancies:
        Web Developer, Web Java developer, Senior C# developer, Plumber
Hello Ann,
We have some changes in vacancies: Senior C# developer

Hello Peter,
We have some changes in vacancies: Web Developer, Web Java developer

Hello Sanka,
We have some changes in vacancies: Plumber

Hello Olik,
We have some changes in vacancies: Senior C# developer

vacancy is removed Web Developer
All vacancies:
        Web Java developer, Senior C# developer, Plumber
Hello Ann,
We have some changes in vacancies: Senior C# developer

Hello Peter,
We have some changes in vacancies: Web Java developer

Hello Sanka,
We have some changes in vacancies: Plumber

Hello Olik,
We have some changes in vacancies: Senior C# developer
 */
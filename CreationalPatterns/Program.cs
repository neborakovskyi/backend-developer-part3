using System.Reflection.Metadata.Ecma335;

namespace CreationalPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Builder();

            FactoryMethod();
        }

        private static void FactoryMethod()
        {
            for (;;)
            {
                Console.WriteLine("Enter delivery type you would like to create:");
                Console.WriteLine("A - Air");
                Console.WriteLine("T - Land");
                Console.WriteLine("S - Sea");
                Console.WriteLine("any key - exit");

                var type = Console.ReadLine();
                var logistic = GetLogistic(type);
                if (logistic == null)
                {
                    return;
                }

                logistic?.PlanDelivery();
            }
        }

        private static Logistic? GetLogistic(string type) =>
            type.ToLower() switch
            {
                "a" => new AirLogistic(),
                "t" => new RoadLogistic(),
                "s" => new SeaLogistic(),
                _ => null
            };

        private static void Builder()
        {
            var houseBuilder = new HouseBuilder("st.Main 1");
            var houseDirector = new HouseDirector(houseBuilder);

            var house = houseBuilder.GetHouse();
            Console.WriteLine(house.ToString());

            house = houseDirector.AddGarage();
            Console.WriteLine(house.ToString());

            house = houseDirector.AddFancyStatues();
            Console.WriteLine(house.ToString());

            var houseWithSwimmingPool = new HouseBuilder("st.Main 2").WithSwimmingPool().GetHouse();
            Console.WriteLine(houseWithSwimmingPool.ToString());

            var houseWithFancyStatues = new HouseBuilder("st.Main 3").WithFancyStatues().GetHouse();
            Console.WriteLine(houseWithFancyStatues.ToString());

            var houseWithGarage = new HouseBuilder("st.Main 4").WithGarage().GetHouse();
            Console.WriteLine(houseWithGarage.ToString());

            var houseWithGarden = new HouseBuilder("st.Main 5").WithGarden().GetHouse();
            Console.WriteLine(houseWithGarden.ToString());
        }
    }
}
/*
House Address: st.Main 1
House facilities:
        Swimming Pool:          no
        Fancy Statues:          no
        Garden:                 no
        Garage:                 no
-------------------------------------------

House Address: st.Main 1
House facilities:
        Swimming Pool:          no
        Fancy Statues:          no
        Garden:                 no
        Garage:                 yes
-------------------------------------------

House Address: st.Main 1
House facilities:
        Swimming Pool:          no
        Fancy Statues:          yes
        Garden:                 no
        Garage:                 yes
-------------------------------------------

House Address: st.Main 2
House facilities:
        Swimming Pool:          yes
        Fancy Statues:          no
        Garden:                 no
        Garage:                 no
-------------------------------------------

House Address: st.Main 3
House facilities:
        Swimming Pool:          no
        Fancy Statues:          yes
        Garden:                 no
        Garage:                 no
-------------------------------------------

House Address: st.Main 4
House facilities:
        Swimming Pool:          no
        Fancy Statues:          no
        Garden:                 no
        Garage:                 yes
-------------------------------------------

House Address: st.Main 5
House facilities:
        Swimming Pool:          no
        Fancy Statues:          no
        Garden:                 yes
        Garage:                 no
-------------------------------------------

 */
/*
Enter delivery type you would like to create:
A - Air
T - Land
S - Sea
any key - exit
a
Delivery type   : Air transport
Enter delivery type you would like to create:
A - Air
T - Land
S - Sea
any key - exit
t
Delivery type   : Land transport
Enter delivery type you would like to create:
A - Air
T - Land
S - Sea
any key - exit
s
Delivery type   : Sea transport
Enter delivery type you would like to create:
A - Air
T - Land
S - Sea
any key - exit
x
 */
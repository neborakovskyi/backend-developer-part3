namespace CreationalPatterns
{
    internal class Program
    {
        static void Main(string[] args)
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
namespace Patterns.Creational
{
    public class House
    {
        public string Address { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasGarden { get; set; }
        public bool HasGarage { get; set; }
        public bool HasFancyStatues { get; set; }

        public House(string address)
        {
            Address = address;
        }

        public override string ToString()
        {
            var isSwimmingPool = HasSwimmingPool ? "yes" : "no";
            var isFancyStatues = HasFancyStatues ? "yes" : "no";
            var isGarden = HasGarden ? "yes" : "no";
            var isGarage = HasGarage ? "yes" : "no";

            var result = $"House Address: {Address} \n\r" +
                                "House facilities: \n\r" +
                                $"\tSwimming Pool: \t\t{isSwimmingPool} \n\r" +
                                $"\tFancy Statues: \t\t{isFancyStatues} \n\r" +
                                $"\tGarden: \t\t{isGarden} \n\r" +
                                $"\tGarage: \t\t{isGarage} \n\r" +
                                "------------------------------------------- \n\r";
            return result;
        }
    }

    public interface IHouseBuilder
    {
        IHouseBuilder WithSwimmingPool();
        IHouseBuilder WithGarden();
        IHouseBuilder WithGarage();
        IHouseBuilder WithFancyStatues();
        House GetHouse();
    }

    public class HouseBuilder : IHouseBuilder
    {
        private readonly House _house;

        public HouseBuilder(string address) => _house = new House(address);
        protected HouseBuilder(House house) => _house = house;

        public IHouseBuilder WithSwimmingPool()
        {
            _house.HasSwimmingPool = true;
            return this;
        }

        public IHouseBuilder WithGarden()
        {
            _house.HasGarden = true;
            return this;
        }

        public IHouseBuilder WithGarage()
        {
            _house.HasGarage = true;
            return this;
        }

        public IHouseBuilder WithFancyStatues()
        {
            _house.HasFancyStatues = true;
            return this;
        }

        public House GetHouse() => _house;
    }

    public class HouseDirector
    {
        private readonly IHouseBuilder _houseBuilder;

        public HouseDirector(IHouseBuilder houseBuilder) => _houseBuilder = houseBuilder;

        public House AddGarage()
        {
            _houseBuilder.WithGarage();
            return _houseBuilder.GetHouse();
        }
        public House AddGarden()
        {
            _houseBuilder.WithGarden();
            return _houseBuilder.GetHouse();
        }
        public House AddSwimmingPool()
        {
            _houseBuilder.WithSwimmingPool();
            return _houseBuilder.GetHouse();
        }
        public House AddFancyStatues()
        {
            _houseBuilder.WithFancyStatues();
            return _houseBuilder.GetHouse();
        }
    }
}

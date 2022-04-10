using System;

namespace AdvancedCSharp.Samples.Class.Inheritance
{
    class FamilyCar : Car
    {
        protected int TrunkCapacityLeft;

        public int TrunkCapacity { get; } = 100;

        public FamilyCar(int speed) : base(speed)
        {
            if (speed > 90)
            {
                throw new ArgumentException("Easy, it's just a family car.");
            }

            TrunkCapacityLeft = TrunkCapacity;
        }

        public void LoadTrunk(int load)
        {
            if (load < 0)
            {
                throw new ArgumentException("Load cannot be negative");
            }

            if (load > TrunkCapacityLeft)
            {
                throw new ApplicationException("The given load exceeds available trunk capacity"); 
                //Create our own exception type here
            }

            //pack the trunk

            //and then reduce its current capacity
            TrunkCapacityLeft -= load;
        }
    }

    class SportCar : Car
    {
        private const int ServiceCheckAfter = 1000; //need to have lower value for SportCar

        public SportCar() : base(200)
        {}

        public SportCar(int speed) : base(speed)
        {
            if (speed < 200)
                throw new ArgumentException($"Speed cannot be lower than 200, actual: {speed}");
        }

        public bool IsServiceCheckNeeded() //this covers method in Car class
        {
            return Distance > ServiceCheckAfter;
        }
    }

    class LuxurySportCar : SportCar
    {}

    public sealed class Bulldozer : Car
    {
        public Bulldozer() : base(15){}


        public void DoSomeWork()
        {

        }
    }


    class CarPresentation
    {
        public static void Main()
        {
            Car car = new Car(90);

            car = new FamilyCar(80);
            car = new SportCar(280);
            car = new LuxurySportCar();
            car = new Bulldozer();
            var isTypeOf = car is ICar;

            Car familyCar = new FamilyCar(80);
            //var capacity = familyCar.TrunkCapacity; // we don't have an access
            var capacity = ((FamilyCar) familyCar).TrunkCapacity;

            SportCar sportCar = new SportCar();
            sportCar = new LuxurySportCar();
            isTypeOf = sportCar is ICar;
            //sportCar = new Car(90); // can't do'
            //you can cast detailed object to more generic implicitly

            CastClassTest(sportCar);
            //CastClassTest(car);
            CastClassTest(new LuxurySportCar());
            //CastClassTest(new Bulldozer());

            //CastInterfaceTest(sportCar);
            //CastInterfaceTest(car);
            //CastInterfaceTest(new LuxurySportCar());
            //CastInterfaceTest(new Bulldozer());
        }

        private static void CastClassTest(SportCar car)
        {

        }

        private static void CastInterfaceTest(ICar car)
        {

        }
    }
}

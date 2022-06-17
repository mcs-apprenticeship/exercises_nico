namespace Exercises_03
{
    public class Program
    {
        public static void Main()
        {

        }
    }

    public abstract class Vehicles
    {
        public abstract int AmountOfWheels { get; }
        public abstract string Color { get; protected set; }

        public Vehicles(string color)
        {
            Color = color;
        }

        public abstract void drive();

        public abstract void stop();
    }

    public class Motorcycle : Vehicles
    {
        public Motorcycle(string color) : base(color){}

        public override int AmountOfWheels { get; } = 2;
        public override string Color { get; protected set; }

        public override void drive()
        {
            Console.WriteLine("Motorcycle started driving");
        }

        public override void stop()
        {
            Console.WriteLine("Motorcycle stopped");
        }
    }

    public class Car : Vehicles
    {
        public Car(string color) : base(color) { }

        public override int AmountOfWheels { get; } = 4;
        public override string Color { get; protected set; }

        public override void drive()
        {
            Console.WriteLine("Car started driving");
        }

        public override void stop()
        {
            Console.WriteLine("Car stopped");
        }
    }

    public class RacingCar : Vehicles
    {
        public RacingCar(string color) : base(color) { }

        public override int AmountOfWheels { get; } = 4;
        public override string Color { get; protected set; }

        public override void drive()
        {
            Console.WriteLine("RacingCar started driving");
        }

        public override void stop()
        {
            Console.WriteLine("RacingCar stopped");
        }
    }

    public class MotorcycleSideCar : Vehicles
    {
        public MotorcycleSideCar(string color) : base(color) { }

        public override int AmountOfWheels { get; } = 3;
        public override string Color { get; protected set; }

        public override void drive()
        {
            Console.WriteLine("MotorcycleSideCar started driving");
        }

        public override void stop()
        {
            Console.WriteLine("MotorcycleSideCar stopped");
        }
    }
}
using System;

namespace DecoratorIceCream
{
    abstract class IceCream
    {
        public abstract string GetDescription();
        public abstract double GetCost();
    }

    class SimpleIceCream : IceCream
    {
        public override string GetDescription()
        {
            return "Simple Ice Cream";
        }

        public override double GetCost()
        {
            return 10.0;
        }
    }

    abstract class IceCreamDecorator : IceCream
    {
        protected IceCream iceCream;

        public void SetIceCream(IceCream iceCream)
        {
            this.iceCream = iceCream;
        }

        public override string GetDescription()
        {
            if (iceCream != null)
                return iceCream.GetDescription();

            return "";
        }

        public override double GetCost()
        {
            if (iceCream != null)
                return iceCream.GetCost();

            return 0;
        }
    }

    class ChocolateDecorator : IceCreamDecorator
    {
        public override string GetDescription()
        {
            return base.GetDescription() + ", Chocolate";
        }

        public override double GetCost()
        {
            return base.GetCost() + 5.0;
        }
    }

    class NutsDecorator : IceCreamDecorator
    {
        public override string GetDescription()
        {
            return base.GetDescription() + ", Nuts";
        }

        public override double GetCost()
        {
            return base.GetCost() + 3.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IceCream iceCream = new SimpleIceCream();

            ChocolateDecorator chocolate = new ChocolateDecorator();
            NutsDecorator nuts = new NutsDecorator();

            chocolate.SetIceCream(iceCream);
            nuts.SetIceCream(chocolate);

            Console.WriteLine(nuts.GetDescription());
            Console.WriteLine("Cost: " + nuts.GetCost());

            Console.Read();
        }
    }
}
using System;

namespace PCConfigurator
{
    class Component
    {
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
    }


    abstract class PCPrototype
    {
        public string Type { get; set; }

        public Component Case { get; set; }
        public Component RAM { get; set; }
        public Component HDD { get; set; }
        public Component Motherboard { get; set; }
        public Component CPU { get; set; }
        public Component GPU { get; set; }
        public Component Monitor { get; set; }

        public abstract PCPrototype Clone();

        public void Show()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Case: {Case.Manufacturer}, {Case.Specification}");
            Console.WriteLine($"RAM: {RAM.Manufacturer}, {RAM.Specification}");
            Console.WriteLine($"HDD: {HDD.Manufacturer}, {HDD.Specification}");
            Console.WriteLine($"Motherboard: {Motherboard.Manufacturer}, {Motherboard.Specification}");
            Console.WriteLine($"CPU: {CPU.Manufacturer}, {CPU.Specification}");
            Console.WriteLine($"GPU: {GPU.Manufacturer}, {GPU.Specification}");
            Console.WriteLine($"Monitor: {Monitor.Manufacturer}, {Monitor.Specification}");
            Console.WriteLine();
        }
    }


    class PC : PCPrototype
    {
        public PC(string type)
        {
            Type = type;
        }

        public override PCPrototype Clone()
        {
            var clone = MemberwiseClone() as PC;

            clone.Case = new Component { Manufacturer = Case.Manufacturer, Specification = Case.Specification };
            clone.RAM = new Component { Manufacturer = RAM.Manufacturer, Specification = RAM.Specification };
            clone.HDD = new Component { Manufacturer = HDD.Manufacturer, Specification = HDD.Specification };
            clone.Motherboard = new Component { Manufacturer = Motherboard.Manufacturer, Specification = Motherboard.Specification };
            clone.CPU = new Component { Manufacturer = CPU.Manufacturer, Specification = CPU.Specification };
            clone.GPU = new Component { Manufacturer = GPU.Manufacturer, Specification = GPU.Specification };
            clone.Monitor = new Component { Manufacturer = Monitor.Manufacturer, Specification = Monitor.Specification };

            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            PC homePC = new PC("Home PC")
            {
                Case = new Component { Manufacturer = "CoolerMaster", Specification = "Mini Tower" },
                RAM = new Component { Manufacturer = "Kingston", Specification = "8GB" },
                HDD = new Component { Manufacturer = "Seagate", Specification = "1TB HDD" },
                Motherboard = new Component { Manufacturer = "ASUS", Specification = "B450" },
                CPU = new Component { Manufacturer = "AMD", Specification = "Ryzen 3" },
                GPU = new Component { Manufacturer = "Integrated", Specification = "Vega Graphics" },
                Monitor = new Component { Manufacturer = "LG", Specification = "22 inch" }
            };


            PC gamingPC = new PC("Gaming PC")
            {
                Case = new Component { Manufacturer = "NZXT", Specification = "Gaming Tower" },
                RAM = new Component { Manufacturer = "Corsair", Specification = "32GB" },
                HDD = new Component { Manufacturer = "Samsung", Specification = "1TB SSD" },
                Motherboard = new Component { Manufacturer = "MSI", Specification = "Z790" },
                CPU = new Component { Manufacturer = "Intel", Specification = "Core i9" },
                GPU = new Component { Manufacturer = "NVIDIA", Specification = "RTX 4080" },
                Monitor = new Component { Manufacturer = "ASUS", Specification = "27 inch 144Hz" }
            };


            PC officePC = new PC("Office PC")
            {
                Case = new Component { Manufacturer = "Dell", Specification = "Compact Case" },
                RAM = new Component { Manufacturer = "Kingston", Specification = "16GB" },
                HDD = new Component { Manufacturer = "WD", Specification = "512GB SSD" },
                Motherboard = new Component { Manufacturer = "Gigabyte", Specification = "B460" },
                CPU = new Component { Manufacturer = "Intel", Specification = "Core i5" },
                GPU = new Component { Manufacturer = "Integrated", Specification = "Intel UHD" },
                Monitor = new Component { Manufacturer = "Samsung", Specification = "24 inch" }
            };

            Console.WriteLine("Prototype PCs created.\n");

            PCPrototype newHomePC = homePC.Clone();
            PCPrototype newGamingPC = gamingPC.Clone();
            PCPrototype newOfficePC = officePC.Clone();

            newHomePC.Show();
            newGamingPC.Show();
            newOfficePC.Show();

            Console.ReadKey();
        }
    }
}
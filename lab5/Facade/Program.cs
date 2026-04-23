using System;

namespace FacadeComputer
{
    namespace ComputerParts
    {
        internal class CPU
        {
            internal string Start()
            {
                return "CPU started\n";
            }
        }

        internal class Memory
        {
            internal string Load()
            {
                return "Memory loaded\n";
            }
        }

        internal class HardDrive
        {
            internal string Read()
            {
                return "Hard Drive reading data\n";
            }
        }
    }

    // Facade
    public static class ComputerFacade
    {
        static ComputerParts.CPU cpu = new ComputerParts.CPU();
        static ComputerParts.Memory memory = new ComputerParts.Memory();
        static ComputerParts.HardDrive hardDrive = new ComputerParts.HardDrive();

        public static void TurnOn()
        {
            Console.WriteLine("Computer starting...\n" +
                cpu.Start() +
                memory.Load() +
                hardDrive.Read());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ComputerFacade.TurnOn();

            Console.Read();
        }
    }
}
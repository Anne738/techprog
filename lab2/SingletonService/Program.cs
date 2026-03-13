using System;

namespace SingletonService
{
    public class Service
    {
        private static readonly Service instance = new Service();

        private string status = "Idle";

        public static Service Instance
        {
            get { return instance; }
        }

        private Service()
        {
        }

        public void DoWork(string message)
        {
            status = "Working";

            Console.WriteLine("Service is working...");
            Console.WriteLine(message);

            status = "Idle";
        }

        public string GetStatus()
        {
            return status;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Service service = Service.Instance;

            Console.WriteLine("Status: " + service.GetStatus());

            service.DoWork("Processing data...");

            Console.WriteLine("Status: " + service.GetStatus());

            Console.ReadKey();
        }
    }
}
using System;

namespace FactoryMethodFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть тип файлу:");
            Console.WriteLine("1 - Текстовий файл");
            Console.WriteLine("2 - Графічний файл");

            string choice = Console.ReadLine();

            FileCreator creator = null;

            if (choice == "1")
                creator = new TextFileCreator();
            else if (choice == "2")
                creator = new ImageFileCreator();
            else
            {
                Console.WriteLine("Невірний вибір");
                return;
            }

            // Factory Method
            File file = creator.FactoryMethod();

            file.Open();

            Console.ReadKey();
        }
    }
}
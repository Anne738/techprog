using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodFiles
{
    class ImageFile : File
    {
        public override void Open()
        {
            Console.WriteLine("Відкрито графічний файл (.png/.jpg)");
        }
    }
}

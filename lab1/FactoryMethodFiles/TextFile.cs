using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodFiles
{
    class TextFile : File
    {
        public override void Open()
        {
            Console.WriteLine("Відкрито текстовий файл (.txt)");
        }
    }
}

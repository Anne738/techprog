using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodFiles
{
    class TextFileCreator : FileCreator
    {
        public override File FactoryMethod()
        {
            return new TextFile();
        }
    }
}

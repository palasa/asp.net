using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorTest
{
    public abstract class Tank
    {
        public List<string> list = new List<string>();

        public abstract void Short();

        public abstract void Run();


    }
}

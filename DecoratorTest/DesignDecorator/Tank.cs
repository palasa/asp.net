using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public abstract class Tank
    {

        public List<string> listdecor = new List<string>();

        public abstract void Short();

        public abstract void Run();
    }
}

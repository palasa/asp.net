using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public class DecoratorIA : Decorator
    {
        public DecoratorIA(Tank model)
            : base(model, "DecoratorIA")
        {

        }

        public override void Short()
        {
            Console.WriteLine("TANK增加红外功能..........");
            base.Short();
        }

        public override void Run()
        {
            base.Run();
        }
    }
}

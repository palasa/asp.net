using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public class DecoratorGPS : Decorator
    {

        public DecoratorGPS(Tank model)
            : base(model, "DecoratorGPS")
        {

        }

        public override void Short()
        {

            Console.WriteLine("TANK增加GPS定位功能..........");

            base.Short();
        }

        public override void Run()
        {
            base.Run();
        }
    }
}

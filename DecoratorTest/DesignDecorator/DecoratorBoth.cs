using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public class DecoratorBoth : Decorator
    {
        public DecoratorBoth(Tank model)
            : base(model, "DecoratorBoth")
        { 
            
        }



        public override void Short()
        {

            base.Short();
        }

        public override void Run()
        {
            Console.WriteLine("TANK增加水路两栖运动能力..........");
            base.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorTest
{
    public class IA : Decorator
    {
        public IA(Tank t)
            : base(t,"IA")
        {
           
        }


        public override void Short()
        {
            Console.WriteLine("坦克加了红外瞄准...");
            base.Short();
        }

        public override void Run()
        {
            base.Run();
        } 
    }
}

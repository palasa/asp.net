using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorTest
{
    public class Gps :Decorator
    {
        public Gps(Tank t)
            : base(t,"Gps")
        {
         
        
        }


        public override void Short()
        {
            Console.WriteLine("坦克加了全球定位瞄准...");
            base.Short();
        }

        public override void Run()
        {
            base.Run();
        } 
    }
}

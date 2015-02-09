using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorTest
{
    public class both : Decorator
    {
        public both(Tank t)
            : base(t,"both")
        {
          
        }


        public override void Short()
        {
            
            base.Short();
        }

        public override void Run()
        {
            Console.WriteLine("坦克加了水陆两栖功能...");
            base.Run();
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public class Tank70 :Tank
    {
        public override void Short()
        {
            Console.WriteLine("T70 TANK 平均射速1000发....");
        }

        public override void Run()
        {
            Console.WriteLine("T70 TANK 移动速度 90公里/小时....");
        }
    }
}

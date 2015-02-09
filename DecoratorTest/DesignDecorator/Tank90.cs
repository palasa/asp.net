using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public class Tank90 :Tank
    {
        public override void Short()
        {
            Console.WriteLine("T90 TANK 平均射速2000发....");
        }

        public override void Run()
        {
            Console.WriteLine("T90 TANK 移动速度 120公里/小时....");
        }
    }
}

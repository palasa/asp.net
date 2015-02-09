using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    public class Tank50 : Tank
    {


        public override void Short()
        {
            Console.WriteLine("T50 TANK 平均射速500发....");
        }

        public override void Run()
        {
            Console.WriteLine("T50 TANK 移动速度 60公里/小时....");
        }
    }
}

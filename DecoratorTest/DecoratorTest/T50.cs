using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorTest
{
    public class T50 : Tank
    {
        public override void Short()
        {
            Console.WriteLine("TANK 50 平均每秒发射5发");
        }

        public override void Run()
        {
            Console.WriteLine("TANK 50 平均 移动速度  60公里/小时");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignDecorator
{
    class Program
    {
        static void Main(string[] args)
        {

            Tank t50 = new Tank50();
            //增加红外瞄准功能
            DecoratorIA tid = new DecoratorIA(t50);
            //增加全球GPS定位瞄准功能
            DecoratorGPS tgps = new DecoratorGPS(tid);
            //增加水路两栖运动功能
            DecoratorBoth tbt = new DecoratorBoth(tgps);

            tbt.Short();

            tbt.Run();

            t50 = tbt.Destory("DecoratorIA", t50);


            t50.Short();
            t50.Run();


            t50 = tbt.Destory("DecoratorGPS", t50);

            t50.Short();
            t50.Run();

            Console.ReadLine();
        }
    }
}

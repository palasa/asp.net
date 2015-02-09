using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorTest
{
    class Program
    {
        static void Main(string[] args)
        {


            Tank t50 = new T50();

            Decorator i = new IA(t50);

            Decorator g = new Gps(i);

            Decorator b = new both(g);

            b.Short();

            b.Run();

            Console.WriteLine();

            t50 = b.remove(new T50(),"IA");

            t50.Short();

            t50.Run();

            Console.WriteLine();

            t50 = b.remove(new T50(), "Gps");

            t50.Short();

            t50.Run();


            Decorator c = new Gps(t50);

            c.Short();
            c.Run();

            Console.ReadKey();
        }
    }
}

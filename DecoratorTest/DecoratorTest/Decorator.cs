using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DecoratorTest
{
    public class Decorator : Tank
    {
        private Tank tank;

        public Decorator(Tank t,string name)
        {
            t.list.Add(name);
            tank = t;
            this.list = tank.list;
        }

        public Tank remove(Tank t, string name)
        {
            this.list.Remove(name);
            Assembly am = Assembly.Load("DecoratorTest");
            foreach (string str in list)
            {
                Type ty = am.GetType("DecoratorTest." + str);
                object[] constuctParms = new object[] { t};
                t = (Tank)Activator.CreateInstance(ty, constuctParms);
            }
            return t;
            
        }

        public override void Short()
        {
            tank.Short();
        }

        public override void Run()
        {
            tank.Run();
        }
    }
}

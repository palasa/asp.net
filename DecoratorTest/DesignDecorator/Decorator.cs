using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DesignDecorator
{
    public class Decorator : Tank
    {
        private Tank tn;

        public Decorator(Tank model,string tname)
        {
            tn = model;
            listdecor = model.listdecor;
            listdecor.Add(tname);
        }

        public override void Short()
        {
            tn.Short();
        }

        public override void Run()
        {
            tn.Run();
        }

        public Tank Destory(string tmodelname, Tank oldmodel)
        {
            List<string> templist = oldmodel.listdecor;

            templist.Remove(tmodelname);

            oldmodel.listdecor = new List<string>();


            Assembly am = Assembly.Load("DesignDecorator");

            for (int i = 0; i < templist.Count; i++)
            {
                Type t = am.GetType("DesignDecorator." + templist[i]);
                oldmodel = (Decorator)Activator.CreateInstance(t, new object[] { oldmodel });
            }

            return oldmodel;
        }
    }
}

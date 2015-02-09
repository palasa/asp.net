using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //硬编码
            //IDECode.IDE code=//反射

            //软编码
            MessageBox.Show(Play("mkv.dll","MKV.ENCode").GetCode());
        }

        private IDECode.IDE Play(string encodename,string typename)
        {
            //通过程序集文件找到Dll文件
            Assembly am = Assembly.LoadFrom(encodename);
            //通过程序集的DLL文件，参数为命名空间.类名获得类型
            Type type = am.GetType(typename);
            //激活当前类型
            return (IDECode.IDE)Activator.CreateInstance(type);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing;

namespace Common
{
    public sealed class CheckCode
    {
        public static object sync = new object();

        static CheckCode _instance;
        /// <summary>
        /// 当前实例
        /// </summary>
        public static CheckCode Instance
        { 
            get
            {
                if (_instance == null)
                {
                    lock (sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new CheckCode();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 设置页面不被缓存
        /// </summary>
        public void SetPageNoCache()
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AppendHeader("Pragma", "No-Cache");
        }

        /// <summary>
        /// 创建随即字符串 /与get 相同
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);//性能问题
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        /// <summary>
        /// 获取随即字符串
        /// </summary>
        /// <param name="CodeCount">字符的数量</param>
        /// <returns></returns>
        public string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(33);

                while (temp == t)
                {
                    t = rand.Next(33);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }

        /// <summary>
        /// 创建图片 /单参数为网站默认的大小，多参数为自定义图片大小
        /// </summary>
        /// <param name="checkCode">图片上生成的字符</param>
        public void CreateImage(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 14);

            using (System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 20))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    Font f = new System.Drawing.Font("Arial ", 10);//, System.Drawing.FontStyle.Bold);
                    Brush b = new System.Drawing.SolidBrush(Color.Black);
                    Brush r = new System.Drawing.SolidBrush(Color.FromArgb(166, 8, 8));

                    //g.FillRectangle(new System.Drawing.SolidBrush(Color.Blue),0,0,image.Width, image.Height);
                    //			g.Clear(Color.AliceBlue);//背景色
                    g.Clear(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));//背景色

                    char[] ch = checkCode.ToCharArray();
                    for (int i = 0; i < ch.Length; i++)
                    {
                        if (ch[i] >= '0' && ch[i] <= '9')
                        {
                            //数字用红色显示
                            g.DrawString(ch[i].ToString(), f, r, 3 + (i * 12), 3);
                        }
                        else
                        {   //字母用黑色显示
                            g.DrawString(ch[i].ToString(), f, b, 3 + (i * 12), 3);
                        }
                    }

                    //for循环用来生成一些随机的水平线
                    //			Pen blackPen = new Pen(Color.Black, 0);
                    //			Random rand = new Random();
                    //			for (int i=0;i<5;i++)
                    //			{
                    //				int y = rand.Next(image.Height);
                    //				g.DrawLine(blackPen,0,y,image.Width,y);
                    //			}

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //history back 不重复 
                    HttpContext.Current.Response.Cache.SetNoStore();//这一句 		
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "image/Jpeg";
                    HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// 创建图片
        /// </summary>
        /// <param name="checkCode">图片上的字符</param>
        /// <param name="defineWidth">图片的宽度</param>
        /// <param name="defineHeight">图片的高度</param>
        /// <param name="WordSize">字符的大小</param>
        public void CreateImage(string checkCode,int defineWidth,int defineHeight,int WordSize)
        {
            int iwidth = (int)(checkCode.Length * defineWidth);

            using (System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, defineHeight))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    Font f = new System.Drawing.Font("Arial ", WordSize);//, System.Drawing.FontStyle.Bold);
                    Brush b = new System.Drawing.SolidBrush(Color.Black);
                    Brush r = new System.Drawing.SolidBrush(Color.FromArgb(166, 8, 8));

                    //g.FillRectangle(new System.Drawing.SolidBrush(Color.Blue),0,0,image.Width, image.Height);
                    //			g.Clear(Color.AliceBlue);//背景色
                    g.Clear(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));//背景色

                    char[] ch = checkCode.ToCharArray();
                    for (int i = 0; i < ch.Length; i++)
                    {
                        if (ch[i] >= '0' && ch[i] <= '9')
                        {
                            //数字用红色显示
                            g.DrawString(ch[i].ToString(), f, r, 3 + (i * 12), 3);
                        }
                        else
                        {   //字母用黑色显示
                            g.DrawString(ch[i].ToString(), f, b, 3 + (i * 12), 3);
                        }
                    }

                    //for循环用来生成一些随机的水平线
                    //			Pen blackPen = new Pen(Color.Black, 0);
                    //			Random rand = new Random();
                    //			for (int i=0;i<5;i++)
                    //			{
                    //				int y = rand.Next(image.Height);
                    //				g.DrawLine(blackPen,0,y,image.Width,y);
                    //			}

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //history back 不重复 
                    HttpContext.Current.Response.Cache.SetNoStore();//这一句 		
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "image/Jpeg";
                    HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                }
            }
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;


namespace Common
{
    public class SetPicture
    {
        private string _path;//上传类型
        private string _fileType;//上传类型
        private int _sizes;//传文件的大小KB(2097152=2MB)
        private int _W;//宽300
        private int _H;//高300
        private bool _smaMap = false;//是否生成缩略图
        private int _mode = 0;//生成方式
        /// <summary>
        /// 上传保存路径
        /// </summary>
        public string Path
        {
            set
            {
                _path = @"\" + value + @"\";
            }
        }
        /// <summary>
        /// 允许上传大小
        /// </summary>
        public int Sizes
        {
            set
            {
                _sizes = value * 1024;//转为字节byte
            }
        }
        /// <summary>
        /// 允许上传类型
        /// </summary>
        public string FileType
        {
            set
            {
                _fileType = value;
            }
        }
        /// <summary>
        /// 缩略图宽度
        /// </summary>
        public int W
        {
            set { _W = value; }
        }
        /// <summary>
        /// 缩略图高度
        /// </summary>
        public int H
        {
            set { _H = value; }
        }
        public bool smaMap
        {
            set { _smaMap = value; }
        }
        /// <summary>
        /// 缩略图生成方式
        /// </summary>
        public int mode
        {
            set { _mode = value; }
        }


        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">实际路径</param>
        /// <param name="thumbnailPath">缩略图存放实际路径</param>
        public void MakeThumbnail(String originalImagePath, String thumbnailPath)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = _W;
            int toheight = _H;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (_mode)
            {
                case 1://指定宽，高按比例                     
                    toheight = originalImage.Height * _W / originalImage.Width;
                    break;
                case 2://指定高，宽按比例 
                    towidth = originalImage.Width * _H / originalImage.Height;
                    break;
                case 3://指定高宽裁减（不变形）                 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * _H / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default://指定高宽缩放（可能变形）   
                    break;
            }

            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
             new Rectangle(x, y, ow, oh),
             GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图 
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("生成缩略图错误：" + ex.Message);
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">实际路径</param>
        /// <param name="thumbnailPath">缩略图存放实际路径</param>
        public void MakeThumbnail(Bitmap bitmap, String originalImagePath, String thumbnailPath)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = _W;
            int toheight = _H;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (_mode)
            {
                case 1://指定宽，高按比例                     
                    toheight = originalImage.Height * _W / originalImage.Width;
                    break;
                case 2://指定高，宽按比例 
                    towidth = originalImage.Width * _H / originalImage.Height;
                    break;
                case 3://指定高宽裁减（不变形）                 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * _H / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default://指定高宽缩放（可能变形）   
                    break;
            }

            //新建一个bmp图片 
            //System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
             new Rectangle(x, y, ow, oh),
             GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图 
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("生成缩略图错误：" + ex.Message);
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


        /// <summary>    
        /// 加入文字水印    
        /// </summary>    
        /// <param name="fileName">文件名称路径(全路径)</param>    
        /// <param name="text">文件</param>    
        public void AddTextToImg(string fileName, string text)
        {
            //判断文件类型是否为图像类型    
            System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);
            float fontSize = 12.0f;//字体大小    
            float textWidth = text.Length * fontSize;//文本的长度    
            //下面定义一个矩形区域,以后在这个矩形里面画上白底黑字    
            float rectX = 0;
            float rectY = 0;
            float rectWidth = text.Length * (fontSize + 8);
            float rectHeight = fontSize + 8;
            //声明矩形域    
            RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);
            Font font = new Font("宋体", fontSize);//定义字体    
            Brush whiteBrush = new SolidBrush(Color.White);//白笔刷,画文字用    
            Brush blackBrush = new SolidBrush(Color.Black);//黑笔刷，画背景用    
            g.FillRectangle(blackBrush, rectX, rectY, rectWidth, rectHeight);
            g.DrawString(text, font, whiteBrush, textArea);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            //输出处理后的图像，这里为了演示方便，我将图片显示在页面中了    
            //Response.Clear();    
            //Response.ContentType = "image/jpeg";    
            //Response.BinaryWrite(ms.ToArray());    
            g.Dispose();
            bitmap.Dispose();
            image.Dispose();
        }

        /// <summary>    
        /// 加入文字水印    
        /// </summary>    
        /// <param name="fileName">文件名称路径(全路径)</param>    
        /// <param name="text">文件</param>    
        public Bitmap AddTextToImg(Bitmap bitmap, string text)
        {
            //判断文件类型是否为图像类型    
            //System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);
            //Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);
            float fontSize = 12.0f;//字体大小    
            float textWidth = text.Length * fontSize;//文本的长度    
            //下面定义一个矩形区域,以后在这个矩形里面画上白底黑字    
            float rectX = 0;
            float rectY = 0;
            float rectWidth = text.Length * (fontSize + 8);
            float rectHeight = fontSize + 8;
            //声明矩形域    
            RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);
            Font font = new Font("宋体", fontSize);//定义字体    
            Brush whiteBrush = new SolidBrush(Color.White);//白笔刷,画文字用    
            Brush blackBrush = new SolidBrush(Color.Black);//黑笔刷，画背景用    
            g.FillRectangle(blackBrush, rectX, rectY, rectWidth, rectHeight);
            g.DrawString(text, font, whiteBrush, textArea);
            //MemoryStream ms = new MemoryStream();
            //bitmap.Save(ms, ImageFormat.Jpeg);
            //输出处理后的图像，这里为了演示方便，我将图片显示在页面中了    
            //Response.Clear();    
            //Response.ContentType = "image/jpeg";    
            //Response.BinaryWrite(ms.ToArray());    
            g.Dispose();
            bitmap.Dispose();
            return bitmap;
            //image.Dispose();
        }
    }
}

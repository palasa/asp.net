using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace web.Fun
{
    //自定义泛型类       泛型约束
    public class Upload<T> where T : Model.UploadBase
    {
        /// <summary>
        /// 上传类的构造器
        /// </summary>
        /// <param name="list">返回的上传文件信息</param>
        /// <param name="hfs">请求文件类的集合</param>
        /// <param name="extension">可保存的文件扩展</param>
        /// <param name="dam">危险类型</param>
        /// <param name="size">文件大小</param>
        /// <param name="saveurl">保存路径</param>
        public Upload(ref List<Model.UploadBase> list
            ,HttpFileCollection hfs
            ,string[] extension
            ,string[] dam
            ,int size
            ,string saveurl)
        {
            if (hfs.Count > 0)
            {
                int count = hfs.Count;
                for (int i = 0; i < count; i++)
                {
                    HttpPostedFile hf= hfs[i];

                    if (hf.FileName == string.Empty)
                    { 
                        //记录错误信息
                        list.Add(new Model.UploadBase() { IsSuccess=false,Message="没有文件"});
                        continue;
                    }

                    //组装保存的文件名

                    string fileclientname = Path.GetFileName(hf.FileName);

                    string extesion = Path.GetExtension(fileclientname);

                    string fileservername = Guid.NewGuid().ToString()+extesion;

                    if (!extension.Contains(extesion))
                    { 
                        //记录错误信息
                        list.Add(new Model.UploadBase() {FileClientName=fileclientname
                            ,FileServerName=fileservername
                            ,Size=hf.ContentLength
                            , IsSuccess = false
                            , Message = "后缀不符合" });
                        continue;
                    }

                    if (hf.ContentLength > size)
                    { 
                        //记录错误信息
                        continue;
                    }

                    //if(dam.Contains())

                    hf.SaveAs(saveurl + fileservername);

                }
            }
            else
            {
                list = null;
            }
        }
    }
}
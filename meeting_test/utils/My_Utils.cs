using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace meeting_test.utils
{
    
    public class My_Utils
    {
        public static void XMLUtils(String key,String value)
        {
             XmlDocument doc01 = new XmlDocument();
                XmlDocument doc02 = new XmlDocument();
                //获得配置文件的全路径  
                string  strFileName01 = AppDomain.CurrentDomain.BaseDirectory + Process.GetCurrentProcess().ProcessName + ".exe.config";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo dir = Directory.GetParent(path);
            
                doc01.Load(strFileName01);
                
                //找出名称为“add”的所有元素  
                XmlNodeList nodes01 = doc01.GetElementsByTagName("add");
                XmlNodeList nodes02 = doc02.GetElementsByTagName("add");
                for (int i = 0; i < nodes01.Count; i++)
                {
                    //获得将当前元素的key属性
                    XmlAttribute att = nodes01[i].Attributes["key"];
                    //根据元素的第一个属性来判断当前的元素是不是目标元素  
                    if (att.Value == key)
                    {
                        //对目标元素中的第二个属性赋值  
                        att = nodes01[i].Attributes["value"];
                        att.Value = value;
                        break;
                    }
                }
                for (int i = 0; i < nodes02.Count; i++)
                {
                    //获得将当前元素的key属性  
                    XmlAttribute att = nodes02[i].Attributes["key"];
                    //根据元素的第一个属性来判断当前的元素是不是目标元素  
                    if (att.Value == key)
                    {
                        //对目标元素中的第二个属性赋值  
                        att = nodes02[i].Attributes["value"];
                        att.Value = value;
                        break;
                    }
                }

                //保存上面的修改  
                doc01.Save(strFileName01);
                
                
        }
    }
}

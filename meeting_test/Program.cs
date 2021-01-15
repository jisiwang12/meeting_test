﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meeting_test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
          

            static System.Diagnostics.Process RunningInstance()
            {
                System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process process in processes) //查找相同名称的进程
                {
                    if (process.Id != current.Id) //忽略当前进程
                    {
                        //确认相同进程的程序运行位置是否一样.
                        if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", @"/") ==
                            current.MainModule.FileName)
                        {
                            //Return the other process instance.
                            return process;
                        }
                    }
                } //No other instance was found, return null.

                return null;
            }
        }
    }
}
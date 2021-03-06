﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Xml;
using meeting_test.domain;
using meeting_test.dao;
using meeting_test.utils;
using Microsoft.Win32;

namespace meeting_test
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            var autorunString = WebConfigurationManager.AppSettings["setautorun"];
            if (autorunString == "0")
            {
                this.SetAutoRun();
                My_Utils.XMLUtils("setautorun", "1");
            }
            this.Auto_Login();
        }
        public bool Sql(){
            My_SqlCon sqlCon = new My_SqlCon();
            var sqlConnection = sqlCon.GetConnection();
            SqlDataReader dr = sqlCon.getSqlDr_Login("select * from usermanage where gh='" + textBox_UserName.Text +
                                                     "'and passwd='" + textBox_Passwd.Text + "'",sqlConnection);
            if (dr.Read())
            { 
                String username = (string)dr[0];
                Main_Menu.userInfo = new UserInfo();
                Main_Menu.userInfo.Username = username;
                Main_Menu.userInfo.Type = (string) dr[2];
                return true;
            }
            dr.Close();
            sqlConnection.Close();
            return false;
           
        }
        //设置开机自启动
        public  void SetAutoRun()
        {
            string path = Application.ExecutablePath;
            RegistryKey rk = Registry.CurrentUser;
            try
            {
                RegistryKey rk2 = rk.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("Meeting", path);
                rk2.Close();
                rk.Close();
            }
            catch (Exception e)
            {
               
            }
           
        }

        public void Auto_Login()
        {
            string usernameConfig = WebConfigurationManager.AppSettings["username"];
            string islogined = WebConfigurationManager.AppSettings["islogined"];
            string passwd = WebConfigurationManager.AppSettings["passwd"];
            if (islogined == "1")
            {
                My_SqlCon sqlCon = new My_SqlCon();
                var sqlConnection = sqlCon.GetConnection();
                SqlDataReader dr = sqlCon.getSqlDr_Login("select * from usermanage where gh='" + usernameConfig +
                                                         "'and passwd='" + passwd + "'",sqlConnection);
                if (dr.Read())
                {
                    String username = (string)dr[0];
                    Main_Menu.userInfo = new UserInfo();
                    Main_Menu.userInfo.Username = username;
                    Main_Menu.userInfo.Type = (string) dr[2];
                    dr.Close();
                    sqlConnection.Close();
                    var thread1 = new Thread(this.openForm);
                    thread1.Start();
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.Sql())
            {
                My_Utils.XMLUtils("username",textBox_UserName.Text.Trim());
                My_Utils.XMLUtils("passwd",textBox_Passwd.Text.Trim());
                My_Utils.XMLUtils("islogined","1");
                /*Main_Menu mainMenu = new Main_Menu();
                mainMenu.ShowDialog();*/
                var thread = new Thread(this.openForm);
                thread.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                textBox_UserName.Clear();
                textBox_Passwd.Clear();
            }
        }

        private void label_Meetting_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            //base.OnClosed(e);
          
        }
        
        private void openForm()
        {
            Application.Run(new Main_Menu());
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var islogined = WebConfigurationManager.AppSettings["islogined"];
            if (islogined=="1")
            {
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}

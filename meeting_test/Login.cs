using System;
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
using System.Web.Configuration;
using System.Xml;
using meeting_test.domain;
using meeting_test.dao;
using meeting_test.utils;

namespace meeting_test
{
    public partial class Login : Form
    {
        public static UserInfo userInfo = null;
        
        public Login()
        {
            InitializeComponent();
            this.Auto_Login();
        }
        public bool Sql(){
          
            My_SqlCon sqlCon = new My_SqlCon();
            SqlDataReader dr = sqlCon.getSqlDr_Login("select * from usermanage where username='" + textBox_UserName.Text +
                                                   "'and passwd='" + textBox_Passwd.Text + "'");

            if (dr.Read())
            {
                String username = (string)dr[0];
                userInfo = new UserInfo();
                userInfo.Username = username;
                return true;
            }

            return false;
           
        }

        public void Auto_Login()
        {
            string usernameConfig = WebConfigurationManager.AppSettings["username"];
            string islogined = WebConfigurationManager.AppSettings["islogined"];
            string passwd = WebConfigurationManager.AppSettings["passwd"];
            if (islogined == "1")
            {
                My_SqlCon sqlCon = new My_SqlCon();
                SqlDataReader dr = sqlCon.getSqlDr_Login("select * from usermanage where username='" + usernameConfig +
                                                         "'and passwd='" + passwd + "'");

                if (dr.Read())
                {
                    String username = (string)dr[0];
                    userInfo = new UserInfo();
                    userInfo.Username = username;
                    Main_Menu mainMenu = new Main_Menu();
                    this.Hide();
                    mainMenu.ShowDialog();
                    this.Close();
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            /*
            My_SqlCon sqlCon = new My_SqlCon();
            SqlDataReader dr = sqlCon.getSqlDr_Login("select * from usermanage where username='" + textBox_UserName.Text +
                                                     "'and passwd='" + textBox_Passwd.Text + "'");

            if (dr.Read())
            {
                String username = (string)dr[0];
                userInfo = new UserInfo();
                userInfo.Username = username;
                
            }
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.Sql())
            {
                My_Utils.XMLUtils("username",textBox_UserName.Text.Trim());
                My_Utils.XMLUtils("passwd",textBox_Passwd.Text.Trim());
                My_Utils.XMLUtils("islogined","1");
                Main_Menu mainMenu = new Main_Menu();
                this.Hide();
                mainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
           
        }

        private void label_Meetting_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

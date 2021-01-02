using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using meeting_test.dao;
using meeting_test.domain;

namespace meeting_test
{
    public partial class Add_Meeting : Form
    {
        private static Add_Meeting _addMeeting=null;

        public static Add_Meeting getAddMeeting()
        {
            if (_addMeeting == null)
            {
                _addMeeting = new Add_Meeting();
            }

            return _addMeeting;
        }
        private Add_Meeting()
        {
            InitializeComponent();
            
        }

      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Add_Meeting_Load(object sender, EventArgs e)
        {
         

            textBox1.Text = Login.userInfo.Username;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            if (dateTime.CompareTo(DateTime.Now) <0)
            {
                dateTimePicker1.Value = DateTime.Now;
                MessageBox.Show("不能小于当前日期");
    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseUser chooseUser = new ChooseUser(1);
            chooseUser.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseUser chooseUser = new ChooseUser(2);
            chooseUser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var mySqlCon = new My_SqlCon();
            String mysql = "insert into task(faqiren,shenheren,time,zherenren,content) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+dateTimePicker1.Value+"','"+textBox3.Text+"','"+richTextBox1.Text+"')";
           
          //  " values ("+textBox1.Text+","+textBox2.Text+","+dateTimePicker1.Value+","+textBox3.Text+richTextBox1.Text+")";
            SqlCommand cmd = mySqlCon.getCmd(mysql);

            if (cmd.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("提交成功");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("服务器正忙，请稍后再试");
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;
using meeting_test.dao;
using meeting_test.domain;


namespace meeting_test
{
    public partial class FormInfo_Sub : Form
    {
        private My_SqlCon mySqlCon = new My_SqlCon();
        private Task task;
        private String mysql;
    
        public FormInfo_Sub(Task task)
        {
            this.task = task;
            InitializeComponent();
        }
        
      

        public FormInfo_Sub()
        {
            
        }

        public void init()
        {
            textBox1.Text = task.Faqiren;
            textBox2.Text = task.Shenheren;
            dateTimePicker1.Text = task.Time;
            textBox3.Text = task.Zherenren;
            comboBox1.Text = task.Bu;
            textBox4.Text = task.Subject;
            richTextBox1.Text = task.Content;
            textBox7.Text = task.Status;
             
        }
        
        public void ChangeTask()
        {
            String mysql = $"update task set changetime='{DateTime.Now.ToString()}',shenheren='{textBox2.Text.ToString()}'," +
                           $"time='{dateTimePicker1.Text.ToString()}',zherenren='{textBox3.Text.ToString()}'," +
                           $"bu='{comboBox1.Text.ToString()}',subject='{textBox4.Text.ToString()}',content='{richTextBox1.Text.ToString()}' " +
                           $"where serial='{task.Serial}'";
            var sqlCon = new My_SqlCon();
            var connection = sqlCon.GetConnection();
            var sqlCommand = sqlCon.getCmd(mysql, connection);
            if (sqlCommand.ExecuteNonQuery() != 0)    
            {
                MessageBox.Show("修改成功");
                connection.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("服务器正忙，请稍后再试");
            }
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            this.init();
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
           this.Close();
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (task.Status != "待完成")
            {
                MessageBox.Show("任务" + task.Status + "，不能修改");
                
            }
            else
            {
                ChangeTask();
            }
            
            
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var chooseUser = new ChooseUser(this, 3);
            chooseUser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var chooseUser = new ChooseUser(this, 4);
            chooseUser.Show();
        }
    }
}

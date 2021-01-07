using System;
using System.Windows.Forms;
using meeting_test.dao;
using meeting_test.domain;


namespace meeting_test
{
    public partial class FormInfo : Form
    {
        private My_SqlCon mySqlCon = new My_SqlCon();
        private Task task;
        private String mysql;
        public FormInfo(Task task)
        {
            this.task = task;
            InitializeComponent();
        }

        public FormInfo()
        {
            
        }

        public void init()
        {
            textBox1.Text = task.Faqiren;
            textBox2.Text = task.Shenheren;
            textBox5.Text = task.Time;
            textBox3.Text = task.Zherenren;
            textBox6.Text = task.Bu;
            textBox4.Text = task.Subject;
            richTextBox1.Text = task.Content;
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            this.init();
            if (task.Status=="待审核")
            {
                button3.Text = "确认审核";
                button4.Text = "退回审核";
               
            }else if (task.Status=="待完成")
            {
                button3.Text = "确认完成";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.button3.Text=="确认审核")
            {
                mysql = $"update task set status='待完成' where serial='{task.Serial}'";
                var cmd = mySqlCon.getCmd(mysql: mysql);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("审核成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("服务器正忙，请稍后再试");
                }
            }
        }
    }
}
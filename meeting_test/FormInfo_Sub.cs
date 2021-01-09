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
            textBox5.Text = task.Time;
            textBox3.Text = task.Zherenren;
            textBox6.Text = task.Bu;
            textBox4.Text = task.Subject;
            richTextBox1.Text = task.Content;
            textBox7.Text = task.Status;
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
    }
}

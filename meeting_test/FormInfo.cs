﻿using System;
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
            textBox7.Text = task.Status;
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            this.init();
            if (task.Status=="待审核" || task.Status=="退回审核")
            {
                button3.Text = "确认审核";
                button4.Text = "退回责任人";
               
            }else if (task.Status=="待处理")
            {
                button3.Text = "确认完成";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text=="返回")
            {
                this.Close();

            }else if (button4.Text=="退回责任人")
            {
                mysql = $"update task set status='审核退回' where serial='{task.Serial}'";
                var cmd = mySqlCon.getCmd(mysql: mysql);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("退回成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("服务器正忙，请稍后再试");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.button3.Text=="确认审核")
            {
                mysql = $"update task set status='已结案' where serial='{task.Serial}'";
                var cmd = mySqlCon.getCmd(mysql: mysql);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("提交成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("服务器正忙，请稍后再试");
                }
            }else if (button3.Text=="确认完成" || button3.Text=="提交")
            {
                mysql = $"update task set status='待审核' where serial='{task.Serial}'";
                var cmd = mySqlCon.getCmd(mysql: mysql);
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
        }
    }
}
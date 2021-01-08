using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using meeting_test.utils;

namespace meeting_test
{
    /**
     * 主菜单界面
     */
    public partial class Main_Menu : Form
    {
        private int button_status = 0;
        public Main_Menu()
        {
            InitializeComponent();
        }
        
        /**
         * 新建会议
         */
        private void 新建会议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Meeting add_Meeting = Add_Meeting.getAddMeeting();
            add_Meeting.ShowDialog();
        }

        /**
         * 显示待办任务窗体
         */
        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear(); //清除右侧窗体控件
            Task_Waitting taskWaitting = new Task_Waitting();
            taskWaitting.TopLevel = false;
            taskWaitting.Dock = DockStyle.Fill;
            taskWaitting.FormBorderStyle = FormBorderStyle.None;
            splitContainer1.Panel2.Controls.Add(taskWaitting);
            taskWaitting.Show();
        }

        /**
          * 显示已提交任务窗体
          */
        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Submitted submitted = new Submitted();
            submitted.TopLevel = false;
            submitted.Dock = DockStyle.Fill;
            submitted.FormBorderStyle = FormBorderStyle.None;
            splitContainer1.Panel2.Controls.Add(submitted);
            submitted.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            label1.Text = Login.userInfo.Username;
            this.Size = new Size(650, 300); //重设窗口大小
            int y = Screen.PrimaryScreen.WorkingArea.Width;
            int x = this.Size.Width;
            if (x > y)
            {
                x = 0;
            }
            else
            {
                x = y - x;
            }

            Point p = new Point(x, 10);
            this.Location = p; //设定初始坐标
            splitContainer1.Panel2.Controls.Clear(); //清除右侧窗体控件
            Task_Waitting taskWaitting = new Task_Waitting();
            taskWaitting.TopLevel = false;
            taskWaitting.Dock = DockStyle.Fill;
            taskWaitting.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.SplitterDistance = 1;
            this.splitContainer1.Panel2.Controls.Add(taskWaitting);
            
            taskWaitting.Show(); //显示任务窗体
            this.splitContainer1.Panel1.Hide();
            this.menuStrip1.Hide();
        }

        private void 账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /**
         * 退出登录
         */
        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_Utils.XMLUtils("islogined", "0");
            Process.Start(Process.GetCurrentProcess().ProcessName + ".exe");
            Application.Exit();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (button_status==0)
            {
                this.splitContainer1.Panel1.Visible = true;
                this.splitContainer1.SplitterDistance = 100;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.menuStrip1.Visible = true;
                button_status = 1;

            }else if (button_status==1)
            {
                button_status = 0;
                this.splitContainer1.Panel1.Visible = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.menuStrip1.Hide();
                this.splitContainer1.SplitterDistance = 2;
                
            }
            

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (button_status==0)
            {
                this.splitContainer1.Panel1.Visible = true;
                this.splitContainer1.SplitterDistance = 100;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.menuStrip1.Visible = true;
                button_status = 1;

            }else if (button_status==1)
            {
                button_status = 0;
                this.splitContainer1.Panel1.Visible = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.menuStrip1.Hide();
                this.splitContainer1.SplitterDistance = 2;
                
            }
        }
    }
}
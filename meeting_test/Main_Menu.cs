using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            splitContainer1.Panel2.Controls.Clear();//清除右侧窗体控件
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
            Point p = new Point(x, 0);
            this.Location = p;
            splitContainer1.Panel2.Controls.Clear();//清除右侧窗体控件
            Task_Waitting taskWaitting = new Task_Waitting();
            taskWaitting.TopLevel = false;
            taskWaitting.Dock = DockStyle.Fill;
            taskWaitting.FormBorderStyle = FormBorderStyle.None;
            splitContainer1.Panel2.Controls.Add(taskWaitting);
            taskWaitting.Show();
    
        }

        private void 账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_Utils.XMLUtils("islogined","0");
            Process.Start(Process.GetCurrentProcess().ProcessName + ".exe");
            Application.Exit();
        }
    }
}
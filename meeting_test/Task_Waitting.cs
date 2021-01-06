using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using meeting_test.dao;

namespace meeting_test
{
    public partial class Task_Waitting : Form
    {
        public Task_Waitting()
        {            
            InitializeComponent();
        }

        private void Task_Waitting_Load(object sender, EventArgs e)
        {
            String mysql = $"select status as 状态,faqiren as 发起人,subject as 会议主题,shenheren as 审核人,content as 项目内容," 
                           + $"time as 完成时间,zherenren as 责任人 from task where zherenren='{Login.userInfo.Username}' or shenheren='{Login.userInfo.Username}' order by sqtime desc";
            My_SqlCon mySqlCon = new My_SqlCon();
            DataSet ds = mySqlCon.getSqlds(mysql);
            dataGridView1.DataSource = ds.Tables[0];
            /*//设置数据表格上显示的列标题
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "课程名称";
            dataGridView1.Columns[2].HeaderText = "学分";
            dataGridView1.Columns[3].HeaderText = "备注";*/
            //设置数据表格为只读
            dataGridView1.ReadOnly = true;
            //不允许添加行
            dataGridView1.AllowUserToAddRows = false;
            //背景为白色
            dataGridView1.BackgroundColor = Color.White;
            //只允许选中单行
            dataGridView1.MultiSelect = false;
            //整行选中
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
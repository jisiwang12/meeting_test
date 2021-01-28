using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using meeting_test.dao;
using meeting_test.domain;

namespace meeting_test
{
    public partial class Submitted : Form
    {
        private Task task;
        public Submitted()
        {
            InitializeComponent();
        }

        private void Submitted_Load(object sender, EventArgs e)
        {
            String mysql = $"select serial as 单号, status as 状态,subject as 会议主题,content as 项目内容,"
                           + $"time as 完成时间,zherenren as 责任人 from task where faqiren='{Main_Menu.userInfo.Username}' order by sqtime desc";
            My_SqlCon mySqlCon = new My_SqlCon();
            var sqlConnection = mySqlCon.GetConnection();
            DataSet ds = mySqlCon.getSqlds(mysql,sqlConnection);
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
            this.dataGridView1.RowHeadersVisible = false;
            sqlConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            task = new Task();
            var mySqlCon = new My_SqlCon();
            var sqlConnection = mySqlCon.GetConnection();
            String serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var dr = mySqlCon.getSqlDr_Login($"select * from task where serial='{serial}'",sqlConnection);
            if (dr.Read())
            {
                task.Id = dr[0].ToString();
                task.Serial = dr[1].ToString();
                task.Shenheren = dr[2].ToString();
                task.Time = dr[3].ToString();
                task.Zherenren = dr[4].ToString();
                task.Content = dr[5].ToString();
                task.Gonghao = dr[6].ToString();
                task.Sqtime = dr[7].ToString();
                task.Status = dr[8].ToString();
                task.Bu = dr[9].ToString();
                task.Faqiren = dr[10].ToString();
                task.Timeformat = dr[11].ToString();
                task.Subject = dr[12].ToString();
            }
            var formInfo_Sub = new FormInfo_Sub(task);
            dr.Close();
            sqlConnection.Close();
            formInfo_Sub.ShowDialog();
        }
    }
}
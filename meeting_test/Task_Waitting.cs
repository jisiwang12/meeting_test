using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using meeting_test.dao;
using meeting_test.domain;
using Task = meeting_test.domain.Task;

namespace meeting_test
{
    public partial class Task_Waitting : Form
    {
        private Task task;
        private My_SqlCon mySqlCon = new My_SqlCon();

        public Task_Waitting()
        {
            InitializeComponent();
        }

        
        
        private void Task_Waitting_Load(object sender, EventArgs e)
        {
            this.setDateView();
        }

        //设置视图的数据和格式
        public void setDateView()
        {
            String mysql = $"select serial as 单号, status as 状态,subject as 会议主题,content as 项目内容,"
                           + $"time as 完成时间,zherenren as 责任人 from task where ((shenheren = '{Main_Menu.userInfo.Username}' and substatus = 1) or (zherenren = '{Main_Menu.userInfo.Username}' and substatus = 0)) and status != '已结案' order by sqtime desc";
            My_SqlCon mySqlCon = new My_SqlCon();
            var sqlConnection = this.mySqlCon.GetConnection();
            DataSet ds = mySqlCon.getSqlds(mysql,sqlConnection);
            this.dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.RowHeadersVisible = false;
            //设置数据表格为只读
            dataGridView1.ReadOnly = true;
            //不允许添加行
            dataGridView1.AllowUserToAddRows = false;
            //背景为白色
            //不允许拖动行
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            // 禁止用户改变列头的高度   
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //只允许选中单行
            dataGridView1.MultiSelect = false;
            //整行选中
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sqlConnection.Close();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                var dataGridViewRow = dataGridView1.Rows[i];
                var nowTime = DateTime.Now.ToString("yyMMdd");
                //完成时间小于当天日期，字体显示为红色
                if (int.Parse(Convert.ToDateTime(dataGridViewRow.Cells["完成时间"].Value.ToString()).ToString("yyMMdd")) -
                    int.Parse(DateTime.Now.ToString("yyMMdd")) < 0)
                {
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
                    dataGridViewRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                    /*if (dataGridViewRow.Cells["状态"].Value.ToString() != "已超时")
                    {
                        var sqlCommand =
                            mySqlCon.getCmd(
                                $"update task set status='已超时' where serial='{dataGridViewRow.Cells["单号"].Value.ToString()}'");
                        sqlCommand.ExecuteNonQuery();
                        dataGridViewRow.Cells["状态"].Value = "已超时";
                    }*/
                    var sqlConnection = mySqlCon.GetConnection();
                    var sqlCommand =
                        mySqlCon.getCmd(
                            $"update task set timeout=1 where serial='{dataGridViewRow.Cells["单号"].Value.ToString()}'",sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    
                }
            }
  
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                task = new Task();
                
                String serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var sqlConnection = mySqlCon.GetConnection();
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
                    task.Timeout = dr[13].ToString();
                    task.Substatus = dr[14].ToString();
                }
                dr.Close();
                sqlConnection.Close();
                var formInfo = new FormInfo(task,this);
                formInfo.ShowDialog();  
            }
            catch (Exception exception)
            {
               
                
            }
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
    }
}
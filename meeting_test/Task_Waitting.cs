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
            String mysql = $"select serial as 单号, status as 状态,subject as 会议主题,content as 项目内容,"
                           + $"time as 完成时间,zherenren as 责任人 from task where (zherenren='{Login.userInfo.Username}' or shenheren='{Login.userInfo.Username}') and status != '已结案' order by sqtime desc";
            My_SqlCon mySqlCon = new My_SqlCon();
            DataSet ds = mySqlCon.getSqlds(mysql);
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
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                var dataGridViewRow = dataGridView1.Rows[i];
                var nowTime = DateTime.Now.ToString("yyMMdd");
                //MessageBox.Show(Convert.ToDateTime(dataGridViewRow.Cells["完成时间"].Value.ToString()).ToString("yyMMdd"));
                if (int.Parse(Convert.ToDateTime(dataGridViewRow.Cells["完成时间"].Value.ToString()).ToString("yyMMdd")) -
                    int.Parse(DateTime.Now.ToString("yyMMdd")) < 0)
                {
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
                    dataGridViewRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                    if (dataGridViewRow.Cells["状态"].Value.ToString() != "已超时")
                    {
                        
                        var sqlCommand =
                            mySqlCon.getCmd(
                                $"update task set status='已超时' where serial='{dataGridViewRow.Cells["单号"].Value.ToString()}'");
                        sqlCommand.ExecuteNonQuery();
                        dataGridViewRow.Cells["状态"].Value = "已超时";
                        
                    }
                }
            }
            /*if (e.RowIndex < 0)
            {
                return;
            }*/
            /*if (dataGridViewRow.Cells["status"].Value.ToString() == "待审核")
            {
                MessageBox.Show(dataGridViewRow.Cells["status"].Value.ToString());
                e.CellStyle.BackColor = Color.Red;
            }
            else
            {
                
            }*/

            /*
            MessageBox.Show("dka");
            String status = this.dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
            if (status =="待审核")
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else if(status=="待完成")
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Brown;
            }
            */
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            task = new Task();
            var mySqlCon = new My_SqlCon();
            String serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var dr = mySqlCon.getSqlDr_Login($"select * from task where serial='{serial}'");
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

            var formInfo = new FormInfo(task);
            formInfo.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
    }
}
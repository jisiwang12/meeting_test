using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using meeting_test.dao;
using meeting_test.domain;

namespace meeting_test
{
    public partial class Add_Meeting : Form
    {
        private My_SqlCon mySqlCon = new My_SqlCon();
        private static Add_Meeting _addMeeting=null;

        public static Add_Meeting getAddMeeting()
        {
            if (_addMeeting == null)
            {
                _addMeeting = new Add_Meeting();
            }
            return _addMeeting;
        }
        private Add_Meeting()
        {
            InitializeComponent();
            
        }

      
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Add_Meeting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Main_Menu.userInfo.Username;
            dateTimePicker1.Value=DateTime.Now;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            if (dateTime.AddHours(2).CompareTo(DateTime.Now) <0)
            {
                dateTimePicker1.Value = DateTime.Now;
                MessageBox.Show("不能小于当前日期");
            }
        }

        /**
         * 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            ChooseUser chooseUser = new ChooseUser(1);
            chooseUser.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseUser chooseUser = new ChooseUser(2);
            chooseUser.ShowDialog();
        }

        /**
         * 生成单号
         */
        private String getSerial()
        {
            String mysql = "";
            String serialString = null;
            var connection = mySqlCon.GetConnection();
            if (comboBox1.Text=="电子线事业部")
            {
                mysql = "select max(left(right(serial,9),6)),MAX(right(serial,9)) from task where serial like 'HLCQ%'";
                DataSet dataSet = mySqlCon.getSqlds(mysql,connection);
                String maxSer = dataSet.Tables[0].Rows[0][0].ToString();
                String maxSerL = dataSet.Tables[0].Rows[0][1].ToString();
                if (maxSer.Equals(DateTime.Now.ToString("yyMMdd")) )
                {
                    serialString= "HLCQ" + (Convert.ToInt32(maxSerL) + 1);
                }
                else
                {
                    serialString= "HLCQ" + DateTime.Now.ToString("yyMMdd") + "001";
                }
                
            }else if (comboBox1.Text=="声学事业部")
            {
                mysql = "select max(left(right(serial,9),6)),MAX(right(serial,9)) from task where serial like 'HLSX%'";
                DataSet dataSet = mySqlCon.getSqlds(mysql,connection);
                String maxSer = dataSet.Tables[0].Rows[0][0].ToString();
                String maxSerL = dataSet.Tables[0].Rows[0][1].ToString();
                if (maxSer.Equals(DateTime.Now.ToString("yyMMdd")) )
                {
                    serialString= "HLSX" + (Convert.ToInt32(maxSerL) + 1);
                }
                else
                {
                    serialString= "HLSX" + DateTime.Now.ToString("yyMMdd") + "001";
                }
            }
            connection.Close();
            return serialString;
        }

        /**
         * 提交数据
         */
        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text.Trim()) || String.IsNullOrEmpty(textBox2.Text.Trim())|| String.IsNullOrEmpty(textBox3.Text.Trim()) || String.IsNullOrEmpty(richTextBox1.Text.Trim()) || String.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                MessageBox.Show("请把表单输入完整！！！");
                
            }
            else
            {
                var serial = this.getSerial();
                String status = "待完成";
                
                //String mysql = "insert into task(faqiren,shenheren,time,zherenren,content,sqtime,bu,serial,subject)"+
                              // " values ('"+textBox1.Text+"','"+textBox2.Text+"','"+dateTimePicker1.Value+"','"+textBox3.Text+"','"+richTextBox1.Text+"','"+DateTime.Now+"','"+comboBox1.Text+"','"+serial+"','"+textBox4.Text+"')";
                              String mysql =
                                  $"insert into task(faqiren,shenheren,time,zherenren,content,sqtime,bu,serial,subject,status,substatus) values ('{textBox1.Text}','{textBox2.Text}','{dateTimePicker1.Value.ToString("yyyy-MM-dd")}','{textBox3.Text}','{richTextBox1.Text}','{DateTime.Now}','{comboBox1.Text}','{serial}','{textBox4.Text}','{status}','0')";
                              var sqlConnection = mySqlCon.GetConnection();
                              SqlCommand cmd = mySqlCon.getCmd(mysql,sqlConnection);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("提交成功");
                    sqlConnection.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("服务器正忙，请稍后再试");
                }
            }
           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Add_Meeting_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
        
        
    }
}

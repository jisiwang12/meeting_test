using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using meeting_test.dao;

namespace meeting_test
{
    public partial class ChooseUser : Form
    {
        private int who;
        private FormInfo_Sub formInfoSub;
        public ChooseUser()
        {
            InitializeComponent();
        }

        public ChooseUser(int who)
        {
            InitializeComponent();
            this.who = who;
            
        }

        public ChooseUser(FormInfo_Sub formInfoSub,int who)
        {
            this.formInfoSub = formInfoSub;
            this.who = who;
            InitializeComponent();

        }




        private void ChooseUser_Load(object sender, EventArgs e)
        {
            string mysql = "select username as 姓名 ,gh as 工号 from usermanage";
            My_SqlCon mySqlCon = new My_SqlCon();
            var sqlConnection = mySqlCon.GetConnection();
            var dataSet = mySqlCon.getSqlds(mysql,sqlConnection);
            dataGridView1.DataSource = dataSet.Tables[0];
            sqlConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String name=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (who==1)
            {
                Add_Meeting.getAddMeeting().textBox2.Text = name;
                
            }

            if (who==2)
            {
                Add_Meeting.getAddMeeting().textBox3.Text = name;
                
            }

            if (who==3)
            {
                formInfoSub.textBox2.Text = name;
                
            }

            if (who==4)
            {
                formInfoSub.textBox3.Text = name;
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mySqlCon = new My_SqlCon();
            var sqlConnection = mySqlCon.GetConnection();

            if (string.IsNullOrEmpty(textBox1.Text)&&String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入查询内容");
                
            }
            //搜索姓名
            if (!String.IsNullOrEmpty(textBox1.Text)&&string.IsNullOrEmpty(textBox2.Text))
            {
                var dataSet = mySqlCon.getSqlds($"select username as 姓名,gh as 工号 from usermanage where username='{textBox1.Text}'",sqlConnection);
                dataGridView1.DataSource = dataSet.Tables[0];
                
                
            }
            //搜索工号
            if (!string.IsNullOrEmpty(textBox2.Text)&&string.IsNullOrEmpty(textBox1.Text))
            {
                var dataSet = mySqlCon.getSqlds($"select username as 姓名,gh as 工号 from usermanage where gh='{textBox2.Text}'",sqlConnection);
                dataGridView1.DataSource = dataSet.Tables[0];
            }

            if (!string.IsNullOrEmpty(textBox1.Text)&&!String.IsNullOrEmpty(textBox2.Text))
            {
                var dataSet = mySqlCon.getSqlds($"select username as 姓名,gh as 工号 from usermanage where username='{textBox1.Text}' and gh='{textBox2.Text}'",sqlConnection);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            
            sqlConnection.Close();
          
        }
    }
}
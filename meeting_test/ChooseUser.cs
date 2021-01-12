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
        public ChooseUser()
        {
            InitializeComponent();
        }

        public ChooseUser(int who)
        {
            InitializeComponent();
            this.who = who;
            
        }
        

        private void ChooseUser_Load(object sender, EventArgs e)
        {
            string mysql = "select username as 姓名 from usermanage";
            My_SqlCon mySqlCon = new My_SqlCon();
            var dataSet = mySqlCon.getSqlds(mysql);
            dataGridView1.DataSource = dataSet.Tables[0];
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
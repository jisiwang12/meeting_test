using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meeting_test
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }


        private void 新建会议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Meeting add_Meeting = Add_Meeting.getAddMeeting();
            add_Meeting.ShowDialog();

        }
    }
}

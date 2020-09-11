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

namespace GUI
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd / MM / yyyy  -  hh:mm:ss") + "      "+ (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString();
            string[] str = s.Split(new string[] { "      " + (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString()}, 
                StringSplitOptions.RemoveEmptyEntries);
            string pp = "";
            for(int i = 0; i < str.Length ; i++)
            {
                pp += str[i];
            }
            lbTime.Text = pp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar1.Increment(1);
            lbPercent.Text = guna2ProgressBar1.ProgressPercentText;
            if (guna2ProgressBar1.Value == 100)
            {
                timer1.Stop();
                lbPercent.Text = "Thành công";
                addFormInPanel(new frmDashboard());
                
            }

        }
        private Form activieForm = null;
        private void addFormInPanel(Form form)
        {
            if (activieForm != null)
            {
                activieForm.Close();
            }
            activieForm = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnContainer.Controls.Add(form);
            this.pnContainer.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value = 0;
            timer1.Start();
           
        }
    }
}

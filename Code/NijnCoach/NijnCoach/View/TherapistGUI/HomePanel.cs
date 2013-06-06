using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NijnCoach.View.TherapistGUI
{
    public partial class HomePanel : Panel
    {
        public HomePanel()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TherapistMain.main.replacePanel(new Qmaker());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            TherapistMain.main.replacePanel(new PatientFiles.UserCreate());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TherapistMain.main.replacePanel(new HomePanel());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TherapistMain.main.Hide();
            new NijnCoach.View.Main.LoginMenu().Show();

        }
    }
}

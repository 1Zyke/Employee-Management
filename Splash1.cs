using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpManagement
{
    public partial class Splash1 : Form
    {
        public Splash1()
        {
            InitializeComponent();
        }

        
        private void Splash1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void MyProgress_ValueChanged(object sender, EventArgs e)
        {

        }
        int startpoint = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint += 1;
            MyProgress.Value = startpoint;
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                this.Hide();
                Login log = new Login();
                log.Show();
            }
        }
    }
}

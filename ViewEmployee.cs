using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmpManagement
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J07K8FJ;Initial Catalog=Employee;Integrated Security=True;");
        private void fetchempdata()
        {
            conn.Open();
            string query = "select * from Empld where id_Emp='" + EmpId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Empidlbl.Text = dr["id_Emp"].ToString();
                empnamelbl.Text = dr["EmpName"].ToString();
                empaddlbl.Text = dr["EmpAdd"].ToString();
                empposlbl.Text = dr["EmpPos"].ToString();
                empphonelbl.Text = dr["EmpPhone"].ToString();
                empedulbl.Text = dr["EmpEdu"].ToString();
                empgenderlbl.Text = dr["EmpGen"].ToString();
                empdoblbl.Text = dr["EmpDOB"].ToString();
                Empidlbl.Visible = true;
                empnamelbl.Visible = true;
                empaddlbl.Visible = true;
                empposlbl.Visible = true;
                empphonelbl.Visible = true;
                empedulbl.Visible = true;
                empgenderlbl.Visible = true;
                empdoblbl.Visible = true;
            }
            conn.Close();
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void Empidlbl_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("========EMPLOYEE SUMMARY==========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(160));
            e.Graphics.DrawString("Employee ID: "+Empidlbl.Text+"\tEmployee Name: "+empnamelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 100));
            e.Graphics.DrawString("Employee Adress: " + empaddlbl.Text + "\tEmployee Gender: " + empgenderlbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 10));
            e.Graphics.DrawString("Employee Position: " + empposlbl.Text + "\tEmployee DOB: " + empdoblbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 180));
            e.Graphics.DrawString("Employee Phone: " + empphonelbl.Text + "\tEmployee Education: " + empedulbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 200));


            e.Graphics.DrawString("========EmpiSoft==========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180, 280));
        }

        private void empgenderlbl_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

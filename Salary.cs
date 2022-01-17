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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J07K8FJ;Initial Catalog=Employee;Integrated Security=True;");
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void fetchempdata()
        {
            if (EmpId.Text  == "")
            {
                MessageBox.Show("Enter The Employee Id");
            }else
            {
                conn.Open();
                string query = "select * from Empld where id_Emp='" + EmpId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    EmpNameTb.Text = dr["EmpName"].ToString();
                    EmpPosTb.Text = dr["EmpPos"].ToString();
                }
                conn.Close();
            }
                
        }
        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }
        int Dailybase,total;

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("========SALARY DOCUMENT==========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            e.Graphics.DrawString("Employee ID: " + EmpId.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 100));
            //e.Graphics.DrawString("Employee Adress: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 10));
            e.Graphics.DrawString("Employee Position: " +EmpPosTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 140));
            e.Graphics.DrawString("Worked Days: " + WorkedTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 180));
            e.Graphics.DrawString("Daily Pay: " + Dailybase, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 220));
            e.Graphics.DrawString("Total Salary: " + total, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(10, 260));


            e.Graphics.DrawString("========EmpiSoft==========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180, 300));
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(EmpPosTb.Text == "")
            {
                MessageBox.Show("Select an Employee");
            } else if (WorkedTb.Text == "" || Convert.ToInt32(WorkedTb.Text) > 28)
            {
                MessageBox.Show("Enter a Valid Number of Days");
            } else
            {
                if(EmpPosTb.Text == "Manager")
                {
                    Dailybase = 1200;
                } else if (EmpPosTb.Text == "Senior Developper")
                {
                    Dailybase = 1000;
                } else if (EmpPosTb.Text == "Junior Developper")
                {
                    Dailybase = 950;
                } else
                {
                    Dailybase = 850;
                }
                total = Dailybase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = "Employee Id: " + EmpId.Text + "\n" + "Employee Name: " + EmpNameTb.Text + "\n" + "Employee Position: " + EmpPosTb.Text + "\n" + "Days Worked: " + WorkedTb.Text + "\n" + "Daily Salary: " + Dailybase + "\n" + "Total Amount: " + total;
            }
        }
    }
}

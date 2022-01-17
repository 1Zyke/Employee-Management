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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J07K8FJ;Initial Catalog=Employee;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();

        private void gunaLineTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (EmpId.Text == "" || EmpName.Text == "" || EmpPhoneTb.Text == "" || EmpAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            } 
            else
            {
                try {
                    conn.Open();
                    string query = "insert into Empld values('" + EmpId.Text + "', '" + EmpName.Text + "', '" + EmpAdd.Text + "', '" + EmpPos.SelectedItem.ToString() + "','" + EmpDob.Value.Date + "','" + EmpPhoneTb.Text + "','" + EmpEduCb.SelectedItem.ToString() + "','" + EmpGen.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    conn.Close();
                    populate();

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            conn.Open();
            string query = "select * from Empld";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpId.Text = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
            EmpName.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAdd.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpEduCb.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
            EmpPos.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpGen.Text = EmpDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (EmpId.Text == "")
            {
                MessageBox.Show("Enter the Employee Id");
            } 
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from Empld where id_Emp = '" + EmpId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    conn.Close();
                    populate();
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpId.Text == "" || EmpName.Text == "" || EmpPhoneTb.Text == "" || EmpAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            } 
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Empld set EmpName='" + EmpName.Text + "',EmpAdd='" + EmpAdd.Text + "',EmpPos='" + EmpPos.SelectedItem.ToString() + "',EmpDOB='"+EmpDob.Value.Date+"',EmpPhone='"+EmpPhoneTb.Text+"',EmpEdu='"+EmpEduCb.SelectedItem.ToString()+"',EmpGen='"+EmpGen.SelectedItem.ToString()+"' where Id_Emp='"+EmpId.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    conn.Close();
                    populate();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
